# SayolloHW SDK
The Sayollow SDK contains: 
  - Video Ads SDK;
  - Purchase View SDK;

# Installation
Download the ```Sayollo HW SDK.unitypackage```, then you need to import it into your project. To do this, you can click ```Assets -> Import Package -> Custom Package...```
and select ```Sayollo HW SDK.unitypackage```

# Sdk structure
<img width="175" alt="Снимок экрана 2022-06-20 в 19 48 26" src="https://user-images.githubusercontent.com/59806365/174662939-ddc99ba7-916c-4d01-bb94-d55646117124.png">

Brief description of folders:
 1) **Animation** - this folder contains an animation of the boot screen.
 2) **Data** - this folder contains configurable data regarding the network connection
 3) **Prefabs** - this folder contains the basic prefabs needed to work with the SDK
 4) **Scripts** - this folder contains the basic scripts needed to work with the SDK

Let's take a closer look at the contents of the **Data** folder.

<img width="255" alt="Снимок экрана 2022-06-20 в 20 05 57" src="https://user-images.githubusercontent.com/59806365/174664840-ec0ee904-7f3d-4a7e-9b8e-3ae6311d05d8.png">

the **Data** folder contains 3 *.ScriptableObjects entities :

**1) ```Apis Config.ScriptableObjects```**

<img width="469" alt="Снимок экрана 2022-06-20 в 20 18 40" src="https://user-images.githubusercontent.com/59806365/174666121-72ad7caa-c7ed-41b5-bb96-4308c8ad2494.png">

This ScriptableObjects is a repository of all APIs. We can configure the API by choosing different:
  - Data key ( IMPORTANT! The data key must be unique. )
  - Data value 
  - Request type (Get, Post, Put)
  - Response format (Json, XML)
  

**2) ```Environments Config.ScriptableObjects```**

<img width="469" alt="Снимок экрана 2022-06-20 в 20 33 01" src="https://user-images.githubusercontent.com/59806365/174667786-e01bf01f-cdfb-4453-98a8-05af95318fe3.png">

This ScriptableObjects is a repository of various server environments. We can customize these environments by changing:
  - Data key ( IMPORTANT! The data key must be unique. )
  - Data value


**3) ```Network Config.ScriptableObjects```**

<img width="469" alt="Снимок экрана 2022-06-20 в 20 42 06" src="https://user-images.githubusercontent.com/59806365/174668756-11a2d904-5471-47ab-aefa-85c356304c79.png">

This ScriptableObjects is a repository of all possible settings for connecting to the server. We can change the value of the main server, change the current server environment.


# Flow of adding

**1) Video Ads SDK**

Put the ```Video Ads SDK.prefab``` on your scene 

![ezgif com-gif-maker](https://user-images.githubusercontent.com/59806365/174673292-ca1b9ca2-d006-4ab1-ac27-c30d1926a08c.gif)

add the main camera to the Video Player component

![ezgif com-gif-maker-2](https://user-images.githubusercontent.com/59806365/174673782-9ac20fa2-95ce-4779-9fa3-2ed7be4e649e.gif)

Great, you can use!

Example: 

![ezgif com-gif-maker-3](https://user-images.githubusercontent.com/59806365/174674170-4676b70e-b78d-4c6e-9eaf-163711b717e7.gif)


