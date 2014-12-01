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


sudo apt-get autoremove mono-complete

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

curl -sSL https://raw.githubusercontent.com/aspnet/Home/master/kvminstall.sh | sh & source ~/.kre/kvm/kvm.sh

source ~/.kre/kvm/kvm.sh

kvm upgrade

mono --version
