![2024-09-01_21-05-58](https://github.com/user-attachments/assets/335b395b-97e1-47fe-b2d4-5a9d08963e1a)


![Sword](https://github.com/user-attachments/assets/cdf6c51a-7fd7-4678-9538-586180aa0021)


This project allows you to create a mesh from a texture. The mesh does not have a wall if there is a pixel next to it.
Generate mesh using Texture, you can also generate with sprite, just when calling Generate, pass sprite.texture to the parameters.
You can also set the scale for mesh generation (scale is only applied to the mesh, not to the object).

A standart unity shader will not work, as it does not display mesh.colors. You can write your own shader or use the material from the example 

You must also set the picture import settings.  "Read/Write" set to true, "Filter mode" set to "Point (no filter)" and Format to "RGBA 32 bit". (See screenshot)


![2024-09-01_20-52-03](https://github.com/user-attachments/assets/36c547a0-bcb0-4b3c-8ca5-2b2d82e2bf68)

