# CFT - Custom Firmware Tuner for Uniden BCD436HP

![screenshot](img/image.png)

### Purpose

The main purpose is to select the parameters of digital protocols that will activate the decryption of encrypted voice traffic. 

The program is designed to work with custom firmware version starting from 1.99.08

The settings must be saved in the file "alice.cft". Place this file at the root directory "\\" of the Scanner's memory card (for example, E:\\).

### Supported decryption protocols

* Hytera BP (Basic Privacy)
    * 10 characters (40 bits) - confirmed
    * 32 characters (128 bits) - confirmed
    * 64 characters (256 bits) - not confirmed
* Motorola BP (Basic Privacy) key 1-255, confirmed
* RC4 - comming soon

### Supported scanner models

* Uniden BCD436HP with [CF 1.99.09](https://github.com/x27/openscanner/releases/tag/BCD436HP_1.99.09)
* Uniden BCD536HP coming soon
* Uniden SDS100 soon maybe (17% of funds raised)
* Uniden SDS200 soon maybe (0% of funds raised)
* Uniden UBCD3600XLT soon maybe (0% of funds raised)

### About Encryption Key

Custom Firmware will not find the Encryption Key. It is something that needs to be obtained in other ways.

### Debug Logs

If you have any problems with signal decryption (or some other problem with my firmware ) and can't figure it out, you need to create debug files and send them to my email.

Separate debug files for each problem separately. Enable logging. Take multiple calls together with pauses. Disable logging. Send Email with problem's description and attached logs.

[More about Debug Logs](DEBUG.md)

### Demo

* Time limit - 2 minutes of decrypted voice of any protocols. Reboot the scanner for reset limitation.
* Key limit - 5 pcs

If you are not satisfied with the limitations of the demo mode, you can purchase unlock keys for the protocol you need. Each unlock key is unique per the Scanner's ESN.

### Donation / Payments

If your scanner model is not supported but you want the claimed features to be there or you just want to support the project, donate or purchase unlock keys for the future.
But before you do, write me an e-mail.

Each unlock key costs 30USD, a pair of keys - 50USD. If you can't afford it with a scanner costing several hundred dollars, write me an email and tell about it. Maybe I can get into your position and lower the price.

For obvious reasons, I would like to remain conditionally anonymous, so payments are only accepted in crypto.

Tether (USDT) TRC20

TFvBYegAgMR5c5CtLCd8NQK1CKmroHHjHq

![wallet](img/wallet.png)

If you don't know what it is try starting here [TrustWallet](https://trustwallet.com/)

### Support

You can support the project not only financially. My mailbox is ready to receive from you any wishes, advice, feedback on the use of the custom firmware and CFT.

### Links

* email: n3617400@yahoo.com
* twitter: https://x.com/openscanner
* telegram: https://t.me/openscanner

