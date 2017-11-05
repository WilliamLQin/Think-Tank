[![Unity](https://img.shields.io/badge/Unity-2017.2.0f3-blue.svg)](https://unity3d.com/)
[![Muse Headband](https://img.shields.io/badge/Muse-2014-yellowgreen.svg)](http://www.choosemuse.com/)
[![Muse Research Tools](https://img.shields.io/badge/Muse%20Research%20Tools-3.4.1-green.svg)](http://developer.choosemuse.com/research-tools)

# Think Tank

![alt icon](https://raw.githubusercontent.com/WilliamLQin/Think-Tank/master/Think%20Tank%201.png)

Train your concentration and lose yourself in this immersive telepathic co-op tank game!
<br>

Last updated November 5, 2017. <br>
Working in Unity 2017.2.0f3. <br>
Tested on Mac OS X Sierra Version 10.12.6 <br>
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

Do this again with the other Muse headband, except replace the port "5000" with "5001". Your command will look like this (XXXX is the other device ID):

```
muse-io --osc osc.tcp://127.0.0.1:5001 --device Muse-XXXX
```

### Visualize and Filter Data in Muse Lab

Open Muse Lab. On a Mac, you will find it at Applications/Muse/MuseLab.app

Select "OSC" in the dropdown menu in the top left. <br>
Click on the "Incoming" tab. <br>
Open a new TCP port at 5000. <br>
Click on the "Outgoing" tab. <br>
Add a new UDP port at 5005. <br>

Select the following two channels in the box that appears to send the data: <br>
* /muse/elements/experimental/concentration
* /muse/elements/jaw_clench

<br>

Open a new window of Muse Lab (this time navigate to the folder and open MuseLab.jar) and repeat the same steps. <br>
The incoming TCP port is at 5001. <br>
The outgoing UDP port is at 5006. <br>

<br>

You can visualize the incoming data from either Muse by selecting "Visualizers" in the dropdown menu in the top left and creating a new Scrolling Line Graph.

### Begin Game

Open Think Tank in Unity. <br>
Open the "Main" scene in Scenes/Main.scene. <br>
Press play and begin using the Muse headbands to control the tank! <br>

The first Muse headband will control the movement of the tank. <br>
Focus and concentrate to move the tank forward and clench your jaw to turn the tank clockwise. <br>
The second Muse headband will control the gun of the tank. <br>
Focus and concentrate to charge the weapon and clench your jaw to release the projectile. <br>

## Troubleshooting

If you can't find the ID of your Muse headband, run this command from the directory of your muse-io command line tool.

```
muse-io
```

This will automatically setup a listener on the default TCP port and tell you the ID of your Muse.

To be able to use multiple Muse headbands at once, you must manually input the target port and device ID.

