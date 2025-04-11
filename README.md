# Azure Environment Variables to appSettings Converter

[![.NET Core](https://img.shields.io/badge/.NET%20Core-6.0-blue)](https://dotnet.microsoft.com/)

A simple utility to convert Azure Web App environment variables (JSON format) to ASP.NET appSettings.config format.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Input Format](#input-format)
- [Output Format](#output-format)
- [Building from Source](#building-from-source)
- [License](#license)

## Features

- Converts Azure environment variables to ASP.NET appSettings format
- Preserves all configuration values
- Simple command-line interface
- Handles special characters and encoding
- Lightweight implementation

## Prerequisites

- .NET 6.0 Runtime or later
- For development: .NET 6.0 SDK

## Installation

1. Download the latest release from the [Releases page](#)
2. Extract the ZIP file to your preferred location
3. Run `AzureEnvToAppSettingsConverter.exe`

Alternatively, you can build from source (see below).

## Usage

1. Prepare your Azure environment variables in JSON format
2. Run the converter:
