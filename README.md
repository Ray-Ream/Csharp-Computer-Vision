# Csharp-Computer-Vision

This project covers the use of C# to write:  
- Image Bit Plane Calculation,  
- Gamma image enhancement,  
- Histogram equalization,  
- Noise reduction filtering,  
- Edge extraction,  
- Hough transform line detection,  
- Hough transform circle detection,  
- High gain filtering,  
- Binocular ranging,  
- Feature template matching
  
and other image processing algorithms


## Table of contents  
- [Getting Started](#getting-started)
- [Image Bit Plane Calculation](#image-bit-plane-calculation)
- [Gamma Image Enhancement](#gamma-image-enhancement)
- [Histogram Equalization](#histogram-equalization)
- [Noise Reduction Filtering](#noise-reduction-filtering)
- [Edge Extraction](#edge-extraction)
- [Hough Transform Line Detection](#hough-transform-line-detection)
- [Hough Transform Circle Detection](#hough-transform-circle-detection)
- [High Gain Filtering](#high-gain-filtering)
- [Binocular Ranging](#binocular-ranging)
- [Feature Template Matching](#feature-template-matching)


### Getting Started
These projects are written in C#.


###### Development configuration requirements
1. **IDE:** Visual Studio 2022 (Community / Professional / Enterprise editions are all supported)  
2. **.NET Framework:** 4.8 or higher, or .NET 6+ for modern C# projects  
3. **UI Framework:** Windows Forms  
4. **Operating System:** Windows 10 or above

###### Installation steps
Clone the repository:  
```sh
https://github.com/Ray-Ream/Csharp-Computer-Vision.git
```

---

### Image Bit Plane Calculation
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/bit-plane-ui.png)

- Click the button to load the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/bit-plane-loadImg.png)

- After loading the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/bit-plane-loadImg-after.png)

- Calculation result:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/bit-plane-processed.png)

---

### Gamma Image Enhancement
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gamma-ui.png)

- Click the button to load the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gamma-loadImg.png)

- After loading the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gamma-loadImg-after.png)

- Gray Scale loaded image:
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gamma-gray-scale.png)

- Calculation result:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gamma-processed.png)

---

### Histogram Equalization
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hist-ui.png)

- Click the button to load and show the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hist-loadImg-after.png)

- Calculation result:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hist-processed.png)

- Calculation result of multiple images:
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hist-processed-multi.png)

---

### Noise Reduction Filtering
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/noise-ui.png)

- Click the button to load and show the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/noise-loadImg.png)

- Calculation result (Mean Filter):  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/noise-mean.png)

- Calculation result (Median Filter):
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/noise-mediam.png)

---

### Edge Extraction
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/edge-ui.png)

- Click the button to load and show the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/edge-loadImg-after.png)

- Calculation result:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/edge-processed.png)

- Calculation result of multiple images:
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/edge-multi.png)

---

### Hough Transform Line Detection
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-line-ui.png)

- Click the button to load and show the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-line-loadImg-after.png)

- Calculation result of Sobel Filter:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-line-sobel.png)

- Calculation result of Hough Line Extraction:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-line-processed.png)

- Calculation result of Hough Line Extraction transform image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-line-transform.png)

---

### Hough Transform Circle Detection
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-circle-ui.png)

- Click the button to load and show the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-circle-loadImg-after.png)

- Calculation result of Sobel Filter:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-circle-sobel.png)

- Calculation result of Hough Circle Extraction:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-circle-processed.png)

- Calculation result of Hough Circle Extraction transform image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/hough-circle-transform.png)

---

### High Gain Filtering
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gain-ui.png)

- Click the button to load and show the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gamma-loadImg-after.png)

- Calculation result of High Gain Filtering (X,Y axis direction):  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gain-processed-xy.png)

- Calculation result of High Gain Filtering (X,Y axis direction and Slope):  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gain-processed-xy-slope.png)

- Calculation result of multiple images (Difference A='1, 1.2, 1.5'):
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/gain-processed-multi.png)

---

### Binocular Ranging
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/binocular-ui.png)

- Click the button to load and display the image, and set the required parameters:  
The set values ​​include the known distances (cm) between the two cameras and the image coordinates of the two objects to be measured (red origins).
*Calculations are performed based on the known coordinates of the red dots.
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/binocular-loadImg-setPos.png)

- Calculation result:  
You can see that the calculated result is 21.61 cm, which is close to the actual result of 20 cm.
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/binocular-processed.png)

---

### Feature Template Matching
- Initial UI interface:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/match-ui.png)

- Click the button to load and display the image:  
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/match-loadImg-after.png)

- Click the button to load and display the the matching target (Red Dot):  
The image size is 64*64 to reduce the amount of calculation required
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/match-load-matchingTarget.png)

- Calculation result:  
You can see in the left and middle pictures that the red dot "matching target" is successfully selected and "calculated/matched"
![image](https://github.com/Ray-Ream/Csharp-Computer-Vision/blob/main/images/match-processed.png)
