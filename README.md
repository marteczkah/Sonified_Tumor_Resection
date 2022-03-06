# Sonified Tumor Resection 
Find more information on [YouTube](https://www.youtube.com/watch?v=OiuYRJCFO7M&t=0s).
## HoloLens Application User Documentation

This documentation explains the details for a correct use of the application. Our solution is a sonified augmented reality validation proof for a tumor resection intervention. The Hololens app shows the user a virtual anatomical model with a tumor that must be removed. The user will be oriented by sonification to the most optimal resection. Thanks to such navigation, malignant tissue can be removed performing less damage to healthy area. At the end of the resection, the user can see the score, which represents the quality of the resection made.

### Hardware Requirements
- Hololens First Generation with application installed
- 2 computers
- 3D printed scalpel and marker
- anatomical model marker 

### Initial Steps
Working with Chuck and Hololens is not straight forward. Chuck code cannot be deployed to Hololens applications. Therefore, we need to run Chuck in external devices and send the pose information from Hololens through OSC messages to use Chuck sounds. Our app is ready to use with no sound, but for using with sound, the following workflow must be followed:

All devices must be connected to the same network, and the IP addresses of the computers must be added to the application code. To do so, open the ‘TumorDistance.cs’ file and, in line 18, enter the IP of computer running the ‘Tumor_sonification.ck’ file. Afterwards, open the ‘VesselSound.cs’ file and enter the IP of the computer running the ‘vesselosc.ck’ code. Finally, build the application and deploy it to Hololens through Visual Studio.

### Application Setup
For a correct tracking quality, a good light in the room is required. The model marker must be situated on a surface clean of objects and the user should locate in front of it.

### Workflow
1.	Turn on and put on the Hololens
2.	Open the application called ‘Final Sonification’
3.	You will see your score in the upper part of your display
4.	Come close to the anatomical model marker to start the tracking
5.	Take the scalpel with your right hand and place it in front of the device so its marker can also be tracked
6.	Move gently the scalpel around the tumor to resect
7.	After the resection is made, the score will appear in the upper part of the display

