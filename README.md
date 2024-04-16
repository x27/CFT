# CFT - Custom Firmware Tuner for Uniden BCDx36HP/SDS100

![screenshot](img/image.png)

### Purpose

The main purpose of CFT is to select the parameters of digital protocols that will activate the decryption of encrypted voice traffic. 

Please read the instructions about [How To Get Started with CFT](HOWTO.md).

### Prerequisites

Requires an installed paid [DMR upgrade](https://info.uniden.com/twiki/bin/view/UnidenMan4/DigitalMobileRadioUpgrade) on the scanner.

Requires an installed custom firmware at least version 1.99.08 on the scanner ([BCD436HP](https://github.com/x27/openscanner/tree/main/uniden/bcd436hp/fw/mod), [BCD536HP](https://github.com/x27/openscanner/tree/main/uniden/bcd536hp/fw/mod), [SDS100](https://github.com/x27/openscanner/tree/main/uniden/sds100/fw/mod)).

OS: Windows XP or higher with installed .Net Framework 2.0

### Download 

The last executable version for Windows you can download [HERE](https://github.com/x27/CFT/releases/latest), placed in the file **CFT.zip**

### Supported decryption protocols

* Hytera BP (Basic Privacy)
    * 10 characters (40 bits) - confirmed
    * 10 characters (40 bits) with OTA Encryption - confirmed
    * 32 characters (128 bits) - confirmed
    * 64 characters (256 bits) - confirmed
    * 64 characters (256 bits) with OTA Encryption - confirmed
* Motorola BP (Basic Privacy) key 1-255 - confirmed
* Motorola BP (Basic Privacy) key 1-255 Mixed with Clear voice - confirmed

### Supported scanner models

* Uniden BCD436HP with [CF 1.99.10](https://github.com/x27/openscanner/releases/tag/BCD436HP_1.99.10)
* Uniden BCD536HP with [CF 1.99.10](https://github.com/x27/openscanner/releases/tag/BCD536HP_1.99.10)
* Uniden SDS100 with [CF 1.99.10](https://github.com/x27/openscanner/releases/tag/SDS100_1.99.10)
* Uniden UBCD3600XLT soon maybe

### Supported scanner modes

* Direct freq entry - confirmed
* Custom Search - confirmed
* Close Call - confirmed
* Quick Search - confirmed
* Memory Scan as a Conventional - confirmed
* Memory Scan as a Digital - confirmed

## Supported trunking modes

* Conventional repeater (Hytera/Motorola) - confirmed
* CAP+ - confirmed
* Connect+ - no data
* DMR Tier III - no data

### About Encryption Key

Custom Firmware will not find the Encryption Key. It is something that needs to be obtained in other ways.

### Debug Logs

If you have any problems with signal decryption (or some other problem with my firmware ) and can't figure it out, you need to create debug files and send it to my email.

Separate debug files for each problem separately.

How to create the debug logs:
* Enable logging.
   - Enable logging by pressing the side Menu button > Settings > Set Debug Log Mode > SD Card (File). Select by pressing on the Volume button.
* Include multiple calls together with pauses.
* Disable logging.
   - Deactivate debug logging via the scanner menu Settings > Set Debug Logs Mode > Off. 
* Send Email with problem's description and attached logs.
   - Debug logs can be found on the scanner SD Card in the /BCDx36HP/debug/ directory. 

[More about Debug Logs](DEBUG.md)

### Virus/Trojan false warning

Some Windows users are triggered by the built-in antivirus when working with the file "alice.cft". This warning is false, which you can verify by checking this file with [VirusTotal](https://www.virustotal.com/gui/home/upload), an online service that combines a huge number of antivirus checks.

### Demo Limitations

* Session time limit - 2 minutes of decrypted voice of any protocols (then turn Off and On device, up to a total of 2 hours)
* Key limit - 5 pcs

If you are not satisfied with the limitations of the demo mode, you can purchase unlock keys for the protocol you need. Each unlock key is unique per the Scanner's ESN.

### Donation / Payments

If your scanner model is not supported, but you want to enjoy these features, or you just want to support the project, you are more than welcome to donate or purchase unlock keys.
But before you do, write me an e-mail.

Licenses for unlocking Hytera BP and Motorola BP keys are currently available. 

For obvious reasons, I would like to remain anonymous, so payments are only accepted in cryptocurrency

#### Crypto payment

Each license costs $30USD, a pair of licenses - $50USD. 

Tether (USDT) TRC20

TFvBYegAgMR5c5CtLCd8NQK1CKmroHHjHq

![wallet](img/wallet.png)

If you don't know what it is try starting here [TrustWallet](https://trustwallet.com/)

Big [How to buy the License(s) with Cryptocurrency](HOWTOCRYPTO.md) with images from well-wisher

#### Payment via Paypal (through an intermediary)

Each license costs $40USD, a pair of licenses - $70USD. 

To receive the Paypal payment address, please first write to me an email and I will give it to you.

In your e-mail, please specify the serial number of the scanner and which license(s) you want to buy.


Donations: 480USDT (9)
* Uniden SDS100 (45% of funds raised)
* Uniden UBCD3600XLT (8% of funds raised)

### Support

Any suggestions, wishes, advice, feedback - email me.

You can also ask your questions or discuss issues with the users' community in the [Telegram chat](https://t.me/+lBpGtQr1FgI0ZWU6) or in the discussion under any post in the [Telegram channel](https://t.me/openscanner)

### Links

* email: n3617400@yahoo.com
* twitter: https://x.com/openscanner
* telegram channel: https://t.me/openscanner
* telegram chat: https://t.me/+lBpGtQr1FgI0ZWU6

