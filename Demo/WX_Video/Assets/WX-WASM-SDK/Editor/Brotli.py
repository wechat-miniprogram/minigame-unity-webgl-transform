#!/usr/bin/python3
# -*- coding: UTF-8 -*-
import os
import sys
import brotli


def main():
    global quiet
    prettier = False
    print("Start!")

    # Brotli
    with open(sys.argv[1], 'rb') as codeBin:
        codeBr = brotli.compress(codeBin.read())
        fout = open(sys.argv[2], "wb")
        fout.write(codeBr)
        fout.close()
        print("Done!")


if __name__ == "__main__":
    main()