# 📹 VideoServer
A lightweight C# application for retrieving, processing, and displaying video streams from IP cameras.

## Overview
VideoServer provides a modular framework for connecting to IP cameras, capturing real‑time video streams, performing motion detection, and running object detection using YOLO. The project includes components for camera management, DirectShow integration, UI control, and stream handling.

## Features
- Connects to IP cameras via HTTP/RTSP  
- Real‑time video stream acquisition  
- WinForms interface for monitoring and control  
- Modular architecture with clear interface boundaries  
- DirectShow support for local video devices  
- **Motion detection module for identifying activity in the frame**  
- **YOLO-based object detection for recognizing objects in real time**

## Project Structure
| Directory | Description |
|----------|-------------|
| **VideoServer** | Core server logic, configuration, and startup |
| **VideoSeverCamers** | IP camera connection and frame retrieval |
| **VideoSeverForm** | WinForms UI for controlling the server |
| **VideoSeverInterfaces** | Interfaces for cameras, streams, and modules |
| **dshow** | DirectShow wrappers and helper utilities |

## Technologies
- C# / .NET Framework  
- WinForms  
- DirectShow  
- HTTP/RTSP streaming  
- **YOLO object detection**  
- **Motion detection algorithms**

## Getting Started
1. Clone the repository:
   ```bash
   git clone https://github.com/maksym-sydorenko/VideoServer.git
