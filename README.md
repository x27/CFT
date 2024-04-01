# CFT - Custom Firmware Tuner for Uniden BCD436HP

![screenshot](img/image.png)

### Purpose

The main purpose is to select the parameters of digital protocols that will activate the decryption of encrypted voice traffic. 

The program is designed to work with custom firmware version starting from 1.99.08

The settings are saved in the file "alice.cft", which should be copied to the root of the scanner's SD card.

### Supported decryption protocols

* Hytera BP (Basic Privacy)
  
    * 10 characters (40 bits) - confirmed
      
    * 32 characters (128 bits) - confirmed
      
    * 64 characters (256 bits) - not confirmed
      
* Motorola BP (Basic Privacy) key 1-255, confirmed

### Supported scanner models

* Uniden BCD436HP

### Debug Logs

For more precise determination of the parameters of voice traffic decryption activation, control info is output to the scanner debug logs.

You can activate debug logging via the scanner menu Settings - Set Debug Logs Mode - SD Card (File). 

The generated debug logs can then be found on the scanner SD Card in the /BCDx36HP/debug/ directory.

#### Debug Log String Format

0201377 :D1 04404400 1 1F 0 01 C 8 68 0000214D 002628B2 0000 1 1 0 0000 0000 0000 D E1F9DA3443BF80 27C2718F2D3600 2F18B5E5C67080 

The debug output string consists of 23 fields separated by a space.

```
1 - Time stamp in microseconds
2 - Signature ":D1" - DMR protocol, version 1
3 - Frequency in 100 Hz scale (DEC)
4 - Data type
    0 - PI Header
    1 - Voice LC Header
    2 - Terminator with LC
    3 - CSBK
    4 - MBC Header
    5 - MBC Continuation
    6 - Data Header
    7 - Rate 1/2 Data
    8 - Rate 3/4 Data
    9 - Idle
    A - Rate 1 Data
    B - Unified Single Block Data
    C - Reserved for future use
    D - Reserved for future use
    E - Reserved for future use
    F - Reserved for future use
5 - Trunk system type
    0 - DMR One?
    1 - Simple DMR
    2 - Capacity+
    3 - Connect+
    4 - DMR Tier III
    5 - Hytera XPT
6 - TDMA channel number
7 - Call type (HEX)
8 - Color code (HEX)
    0 - F
9 - Superframe number (HEX)
    0 - B
10 - EMB FID manufacturer identifier (HEX)
    10 - Motorola
    68 - Hytera
11 - EMB TGID talkgroup number (HEX)
12 - EMB User ID (HEX)
13 - C-CH 
14 - Encrypt Value
    1 - Non encrypted
    2 - Encrypted
15 - Privacy
16 - EMB Privacy
17 - SLC LCN
18 - SLC NID
19 - SLC SID
20 - Voice traffic decryption identifier
  D - Parameters are not defined
  U - Protocol unlocked
  A - Allowed
  S - Time session restriction
21 - Voice packet 0, 49 bits (HEX)
22 - Voice packet 1, 49 bits (HEX)
23 - Voice packet 2, 49 bits (HEX)
```

### Demo

* Time limit - 2 minutes of decrypted voice. Reset the scanner for restart.

* Key limit - 5

### Debug Logs Filtering Tool

![filering](img/filtering.png)

### Other

crypto:

USDT TRC20 TFvBYegAgMR5c5CtLCd8NQK1CKmroHHjHq

text:

n3617400@yahoo.com
