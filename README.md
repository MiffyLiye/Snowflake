# Snowflake
[![AppVeyor branch](https://img.shields.io/appveyor/ci/MiffyLiye/Snowflake/master.svg?style=flat-square&label=windows%20build)](https://ci.appveyor.com/project/MiffyLiye/snowflake/branch/master)
[![Travis branch](https://img.shields.io/travis/MiffyLiye/Snowflake/master.svg?style=flat-square&label=linux%20build)](https://travis-ci.org/MiffyLiye/Snowflake)
[![Codecov branch](https://img.shields.io/codecov/c/github/MiffyLiye/Snowflake/master.svg?style=flat-square)](https://codecov.io/gh/MiffyLiye/Snowflake)

[![NuGet](https://img.shields.io/nuget/v/MiffyLiye.Snowflake.svg?style=flat-square)](https://www.nuget.org/packages/MiffyLiye.Snowflake/)
[![Libraries.io for GitHub](https://img.shields.io/librariesio/github/MiffyLiye/Snowflake.svg?style=flat-square)](https://libraries.io/github/MiffyLiye/Snowflake)

A simple ID generator inspired by Twitter's snowflake.

## ID properties
* 1 bit leading 0 to ensure the long number is positive 
* 41 bits for timestamp
* 10 bits for machine ID
* 12 bits random number
* ~2 ms timestamp precision
* ~139 years timestamp range
* generate 1 ID in less than 1 ms
* concurrently generate 4096 unique IDs in less than 0.1 s

## Aspirations
* Make simple things simple
* Make complex things possible
* Support centralized low traffic system
* Support distributed high traffic system
* Portable to Windows, macOS, and Linux

## Status
* Support centralized low traffic system
* Support distributed high traffic system (< 4096 requests per 100 millisecond per machine)

## Usages
See test cases.

## Issues
See project issues.
