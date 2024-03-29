# Me
My name is Aaron and I am diditoday on the Discord server. I love designing missions for VTOL VR.

## My YouTube
I have a couple of YouTube channels dedicated to VTOL VR. 

[VTOL VR Make Stuff](https://www.youtube.com/playlist?list=PL6zz6YGMo8_QdAXaQzZOAAgu7B42P00rU)

[VTOL VR Learn Stuff](https://www.youtube.com/playlist?list=PL6zz6YGMo8_RTIzyZupO-wV9wDDusJRyS)

They aren't the best but they aren't bad either. They are videos to try to help show and understand how the mission editor works in VTOL VR.

## The Shlabovian Conflict
I am trying to create an arc in VTOL VR called The Shlabovian Conflict or TSC and made the first entry in the series [here](https://steamcommunity.com/sharedfiles/filedetails/?id=2366824583). I was not able to finish the game as my computer had issues and I lost files, so it is dead. Which is ok because I'll just move onto other games I planned. 

Anyway, enough about me.

# VTOLVR-MissionAssistant
## The Project
It is just me on this project for now but others may join in the future who knows. 

# The Application
VTOL VR Mission Assistant helps in managing and modifying the VTS file for VTOL VR missions. However, it is not a replacement for the mission editor in VTOL VR itself. It just provides some extra functionality I wish was natively there. Like the ability to re-index your units so they are sequential again or the ability to copy events or objectives.

Major point of usage. DO NOT use the application while VTOL VR is running. In fact the application won't launch if you are running VTOL VR. Just best to avoid two applications trying to manage the same file. Second major point of usage. The application automatically backs up the VTS file before making any modifications to it.

## VTS API
This application uses the [VTS API](https://github.com/AaronAmberman/VTS.Data) I made to assist in reading and writing VTS files. Please check it out.

# Alpha Development
I've started development and have been working to build out the UI and basic ingestion workflow.

![image](https://user-images.githubusercontent.com/23512394/220999012-76e4cb00-7069-479e-82dc-cdb19e563b83.png)

![image](https://user-images.githubusercontent.com/23512394/222927673-b973c62c-9932-4808-babd-ad740b9cd6d1.png)

![image](https://user-images.githubusercontent.com/23512394/222927681-0b107152-55d1-45e5-96cc-6a4cc3abe3c2.png)

![image](https://user-images.githubusercontent.com/23512394/220999419-2b8f336a-a097-425c-9429-e4fa79b32510.png)

Translations include English, Chinese, Korean, Japanese and Russian.

# Beta
I have added a setup directory with a build of the software.

## Known Issues
Location points are truncated down from up to 15 characters. I plan on convert the values to strings in the future as I do not need numbers...I do no calculations with them. Or if I can figure out a more proper conversion from float to string then string back to float. Proper in terms of matching the previous output.
