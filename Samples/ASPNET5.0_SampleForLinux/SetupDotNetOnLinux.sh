#!/bin/bash

clear

PREFIX=$1
VERSION=$2

if [ -z $PREFIX ]; then
  PREFIX="/usr/local/"
fi

if [ -z $VERSION ]; then
  VERSION="3.10.0"
fi


sudo apt-get install make
sudo apt-get install git autoconf libtool automake build-essential mono-devel gettext zip unzip
sudo apt-get install bash zsh curl

sudo mkdir $PREFIX
sudo chown -R `whoami` $PREFIX

PATH=$PREFIX/bin:$PATH
wget http://download.mono-project.com/sources/mono/mono-$VERSION.tar.bz2
tar -xjvf mono-$VERSION.tar.bz2
cd mono-$VERSION
./autogen.sh --prefix=$PREFIX
make
make install

sudo certmgr -ssl -m https://go.microsoft.com
sudo certmgr -ssl -m https://nugetgallery.blob.core.windows.net
sudo certmgr -ssl -m https://nuget.org
sudo certmgr -ssl -m https://www.myget.org/F/aspnetvnext/

mozroots --import –sync

wget http://dist.libuv.org/dist/v1.0.0-rc1/libuv-v1.0.0-rc1.tar.gz 
tar -xvf libuv-v1.0.0-rc1.tar.gz
cd libuv-v1.0.0-rc1/
./gyp_uv.py -f make -Duv_library=shared_library
make -C out
sudo cp out/Debug/lib.target/libuv.so /usr/lib/libuv.so.1.0.0-rc1
sudo ln -s libuv.so.1.0.0-rc1 /usr/lib/libuv.so.1

curl -sSL https://raw.githubusercontent.com/aspnet/Home/master/kvminstall.sh | sh & source ~/.kre/kvm/kvm.sh

source ~/.kre/kvm/kvm.sh

kvm upgrade

mono --version
