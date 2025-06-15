# Debug Logs

For more precise determination of the parameters of voice traffic decryption activation, control info is output to the scanner debug logs.

You can activate debug logging via the scanner menu Settings - Set Debug Logs Mode - SD Card (File). 

The generated debug logs can then be found on the scanner SD Card in the /BCDx36HP/debug/ directory.

#### Debug Log String Format

##### AE1 - P25 Phase 1 - Raw Data

```
0223347 :AE1 05 00 FEC1DB87A5C81DBB
1       2    3  4  5 
```
The debug output string consists of 5 fields separated by a space.
```
1 - Time stamp in microseconds
2 - Signature ":AE1"
3 - DATA UNIT ID. 00 - HDU, 05 - LDU1, 0A - LDU2 
4 - STATE MACHINE NUMBER
5 - 8 bytes raw data
```

##### AV1 - P25 Phase 1 - Voice Data Debug Info

```
0224382 :AV1 04460062 0293 0001 00770BB2 00000000 00 00AA 0000 07 A25A2BA4DC65CB98E486A4277769A17DA642
1       2    3        4    5    6        7        8  9    10   11 12
```
The debug output string consists of 12 fields separated by a space.
```
1 - Time stamp in microseconds
2 - Signature ":AV1"
3 - Frequency in 100 Hz scale (DEC)
4 - NAC
5 - TGID
6 - SID
7 - DID
8 - KID
9 - ALGID
    80 - CLEAR
    81 - DES
    83 - 3DES
    84 - AES256
    AA - ADP
10 - MFID
11 - Processing Number, 1-9
12 - Voice Packet IMBE, 88 bits
```

##### AL1 - P25 Phase 1 - MI

```
0224382 :AL1 000000000000000000 111111111111111111
1       2    3                  4
```
The debug output string consists of 4 fields separated by a space.
```
1 - Time stamp in microseconds
2 - Signature ":AL1" - MI from air and LFSR calculated from previous value
3 - MI from air, 9 bytes
4 - MI, LSFR calculated from previous value, 9 bytes
```

##### AM1 - P25 Phase 1 - MI (valid), ALGID, KID
```
0224382 :AM1 000000000000000000 80 0000
1       2    3                  4  5
```
The debug output string consists of 5 fields separated by a space.
```
1 - Time stamp in microseconds
2 - Signature ":AM1" - MI, ALGID, KID
3 - MI, 9 bytes 
4 - ALGID
5 - KID
```

##### MI - DMR

```
0066766 :MI 0 9974B94B 9974B94B  0 21 01
1       2   3 4        5         6 7  8
```
The debug output string consists of 8 fields separated by a space.

```
1 - Time stamp in microseconds
2 - Signature ":MI" - IV and addition info
3 - BPTC error. If =0 then assign new IV
4 - Calculated IV (by Motorola LFSR algo)
5 - Extracted IV from control frames. For Moto EP must be Field(4) = Field (5)
6 - BPTC16 error. If !=0 and known AlgoID then assign new encryption params
7 - AlgoID
    21 - RC4
    22 - DES
    24 - AES128
    25 - AES256
8 - KeyID
```
##### N0 - NXDN Control and Voice Info

```
0067268 :N0 04307750 02 04 02 02 00 00 0000 00000000 00000003 D 1 01 28139 0 105D02A0246A00 90FF381CC07A00 C32EA656008700 98B3C2806C4200 
1       2   3        4  5  6  7  8  9  10   11       12       131415 16    1718             19             20             21
```
The debug output string consists of 21 fields separated by a space.

```
1 - Time stamp in microseconds
2 - Signature ":N0" - NXDN protocol, version 0
3 - Frequency in 100 Hz scale (DEC)
4 - NXDN Frame Type
    Range: 0-8
5 - NXDN Data Type
    0 - SACCH
    1,5,6 - FACCH1
    2 - FACCH2
    3 - CAC
6 - NXDN Vocoder Mode
    Range: 0-3
7 - RAN
8 - AREA
9 - SITE
10 - SYSTEM
11 - GROUP ID
12 - UID
13 - Voice traffic decryption identifier
  D - Parameters are not defined
  U - Protocol unlocked
  A - Allowed
  S - Time session restriction
14 - NXDN Cypher Type
    0 - Non Ciphered
    1 - Scrambler
    2 - Des
    3 - Aes
15 - Key ID
16 - NXDN Current Scrambler Key (DEC)
17 - NXDN Scrambler Key Offset
    Inner control data
18 - Voice packet 0, 49 bits (HEX)
19 - Voice packet 1, 49 bits (HEX)
20 - Voice packet 2, 49 bits (HEX)
21 - Voice packet 3, 49 bits (HEX)
```

##### D1 - DMR Control and Voice Info

```
0201377 :D1 04404400 1 1F 0 01 C 8 68 0000214D 002628B2 0000 1 1 0 0000 0000 0000 D E1F9DA3443BF80 27C2718F2D3600 2F18B5E5C67080 
1       2   3        4 5  6 7  8 9 10 11       12       13   14151617   18   19   2021             22             23
```

The debug output string consists of 23 fields separated by a space.

```
1 - Time stamp in microseconds
2 - Signature ":D1" - DMR protocol, version 1
3 - Frequency in 100 Hz scale (DEC)
4 - Trunk system type
    0 - DMR One?
    1 - Simple DMR
    2 - Capacity+
    3 - Connect+
    4 - DMR Tier III
    5 - Hytera XPT
5 - Data type
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
    1E - ?
    1F - ?
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


