# JM Tools ~ Build System

Build system for Unity plus itch.io integration through butler

## Prerequisites

You must include the [JM Tools Core](https://github.com/MrJoshuaMcLean/jmtools-core) in your project.

To upload builds to itch.io, you will need to have butler installed and setup.

1. Download butler from itch.io: https://fasterthanlime.itch.io/butler
2. Extract to a directory on your computer
3. On Windows, add butler to your path (TODO other OS's)
4. TODO how to setup your account with butler

## Usage

1. Place the JM Tools Build System source in a directory under your project's
   `Assets` directory.
2. Go to Window -> JM Tools -> Build Window
3. Have fun (TODO more documentation)

## Optional Features

To enable Zip operations, define `JM_BUILD_ZIP` in Project Settings -> Player ->
Other Settings -> Configuration -> Script Define Symbols.

Zip operations (ZipFile class) may not work on non-Windows sytems (untested). 

## Troubleshooting

`Win32Exception: The system cannot find the file specified.`

This can occur when clicking "Upload" if the butler path is incorrect.

