# NoMoreLEDs

Disables RGB and non-RGB LEDs on MSI GPUs.

## tl;dr

- You agree to not hold me or MSI responsible if your GPU gets destroyed by using this program.
- Install MSI Gaming App and copy over NDA.dll next to this program's binary (NoMoreLEDs.exe).
  You can find it in `C:\Program Files (x86)\MSI\Gaming APP\Lib`. It can't be distributed with
  NoMoreLEDs due to licensing issues.
- Start it once from the command line to see if there are any issues (shouldn't be any if using
  a supported MSI GPU).
- If it works, put NoMoreLEDs in Autostart and forget about LEDs.

## FAQ

- **Can it break my GPU?** Yes. I don't know how NDA.dll exactly talks to the GPU, and the exact
  parameters used to disable LEDs were just sniffed. (Standard Nvidia utils to toggle LEDs do not
  work here.)
- **Can I use that library to manipulate my GPU?** Yes, but there are no guarantees it'll work.
  Furthermore there are functions which allow you to set potentially dangerous values on your
  hardware, and that may damage it permanently. You break it, you keep it.
- **You think it's safe?** No. I've seen how it more or less works, and... it's not pretty. Well,
  MSI's Gaming App uses this to manipulate all the values just fine, and I suppose they do know
  what they're doing, but getting occasional random errors for virtually no reason shouldn't be
  something you'd ignore while setting voltages and such on your hardware. That's up to you.
- **NDA.dll instantly breaks on the first call, something something assembly something.** It's
  a 32-bit binary, and you probably have Any CPU set in your configuration. Any CPU = 64-bit on
  64-bit OSes, 32-bit on 32-bit OSes, you'll have to force 32-bit configuration in your Project
  -> Properties -> Build -> Platform Target -> x86.

## License

NoMoreLEDs is available under the MIT License. See LICENSE for more information.

## NDA.dll License

**Due to licensing reasons, we cannot distribute NDA.dll. You'll have to copy it
over yourself from your MSI Gaming App installation. Afterwards you can uninstall
the app, NDA.dll does all the required work itself.**

Copyright (c) 2014 MICRO-STAR INTERNATIONAL CO., LTD.

MSI MAKES NO REPRESENTATION OR WARRANTY REGARDING THE PERFORMANCE OR COMPATIBILITY OF
SOFTWARE. TO THE FULLEST EXTENT PERMITTED BY LAW, SOFTWARE IS PROVIDED “AS IS” WITHOUT
ANY EXPRESS OR IMPLIED WARRANTY, INCLUDING BUT NOT LIMITED TO IMPLIED WARRANTY OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NO FAULT, NON-INFRINGEMENT, WARRANTY
OF TITLE, COMPONENT OR SYSTEM STABILITY, PERFORMANCE, CONTINUED USE, AND UNINTERRUPTED
SERVICE. YOU ASSUME FULL RISK FOR YOUR USE OF SOFTWARE.
