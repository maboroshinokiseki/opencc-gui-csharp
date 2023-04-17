/* Copyright (C) 1991-2018 Free Software Foundation, Inc.
   This file is part of the GNU C Library.
   Written by Torbjorn Granlund (tege@sics.se),
   with help from Dan Sahlin (dan@sics.se);
   commentary by Jim Blandy (jimb@ai.mit.edu).
   The GNU C Library is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 2.1 of the License, or (at your option) any later version.
   The GNU C Library is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.
   You should have received a copy of the GNU Lesser General Public
   License along with the GNU C Library; if not, see
   <http://www.gnu.org/licenses/>.  */

namespace OpenCC_GUI
{
    using System;
    using System.Runtime.InteropServices;

    public static class String
    {
        public static int Strlen(IntPtr ptr)
        {
            //Make sure the pointer is aligned
            for (IntPtr orig_ptr = ptr; ptr.ToInt64() % 8 != 0; ptr += 1)
            {
                if (Marshal.ReadByte(ptr) == '\0')
                {
                    return (int)(ptr.ToInt64() - orig_ptr.ToInt64());
                }
            }

            //Represent 0x8080808080808080UL in long
            long himagic = -0x7F7F7F7F7F7F7F80L;
            long lomagic = 0x0101010101010101L;

            for (int i = 0; ; i += 8)
            {
                long longword = Marshal.ReadInt64(ptr, i);
                if (((longword - lomagic) & ~longword & himagic) != 0)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Marshal.ReadByte(ptr, i + j) == 0)
                        {
                            return i + j;
                        }
                    }
                }
            }
        }
    }
}
