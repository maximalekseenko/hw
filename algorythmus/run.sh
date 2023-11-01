#!/bin/bash/env bash
BASE_DIR=$(dirname "$0")
BUILD_DIR=$BASE_DIR/build/
SRC_DIR=$BASE_DIR/src/

# make build directory
if [ ! -d $BUILD_DIR ]; then
    mkdir $BUILD_DIR
fi

# build
g++ -std=c++20 -o $BUILD_DIR/build $SRC_DIR/main-$1.cpp -fsanitize=address -fdiagnostics-color=always

# run
$BUILD_DIR/build
rm -r $BUILD_DIR/build