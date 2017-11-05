[![Unity](https://img.shields.io/badge/Unity-2017.2.0f3-blue.svg)](https://unity3d.com/)
[![Muse Headband](https://img.shields.io/badge/Muse-2014-yellowgreen.svg)](http://www.choosemuse.com/)
[![Muse Research Tools](https://img.shields.io/badge/Muse%20Research%20Tools-3.4.1-green.svg)](http://developer.choosemuse.com/research-tools)

# Think Tank

![alt icon]()

Train your concentration and lose yourself in this immersive telepathic co-op tank game!
<br>

Last updated November 5, 2017. <br>
Working in Unity 2017.2.0f3. <br>
Requires Muse headband 2014 model, Muse-IO is not supported by Muse headband 2016. <br>

## Built With

* [Unity](https://unity3d.com/) - Game engine and IDE for creating games!
* [Muse Headband](http://www.choosemuse.com/) - Brain sensing headband with electroencephalography (EEG) sensors.
* [Muse Research Tools](http://developer.choosemuse.com/research-tools) - Muse-IO and Muse Lab for receiving and passing sensor data.

## Minimum Requirements

* Two Muse headbands
* Bluetooth for communicating with Muse headband

## Getting Started

### Download and Install Tools

Download and install the Muse SDK and Research Tools from [here](http://developer.choosemuse.com/research-tools).

### Setup Muse Listener

Turn on the Muse headbands by holding the power button until the LEDs are blinking (about 6 sec) and pair the headbands with your computer via bluetooth.

In terminal, head to the directory of your muse-io command line tool. <br>
On a Mac, this is typically in Applications/Muse. <br>
Run this command to start listening for data from your Muse headband: <br>

```
  muse-io --osc osc.tcp://127.0.0.1:5000 --device Muse-XXXX
```

Replace XXXX with the unique ID of your Muse headband. You can find this ID in the name of the headband when connecting to bluetooth.

Do this again with the other Muse headband, except replace the port ("5000") with a different port except for "5005" or "5006". Your command will look like this (XXXX is the other device ID):

```
  muse-io --osc osc.tcp://127.0.0.1:5001 --device Muse-XXXX
```

### Visualize and Filter Data in Muse Lab




## Troubleshooting

If you can't find the ID of your Muse headband, run this command from the directory of your muse-io command line tool.

```
  muse-io
```

This will automatically setup a listener on the default TCP port and tell you the ID of your Muse.

To be able to use multiple Muse headbands at once, you must manually input the target port and device ID.

