# Snowflake
[![AppVeyor branch](https://img.shields.io/appveyor/ci/MiffyLiye/Snowflake/master.svg?style=flat-square)](https://ci.appveyor.com/project/MiffyLiye/snowflake/branch/master)
[![Codecov branch](https://img.shields.io/codecov/c/github/MiffyLiye/Snowflake/master.svg?style=flat-square)](https://codecov.io/gh/MiffyLiye/Snowflake)
[![Codacy branch grade](https://img.shields.io/codacy/grade/8568d054474f48aca7c900aa099ab4ac/master.svg?style=flat-square)](https://www.codacy.com/app/miffyliye/Snowflake?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=MiffyLiye/Snowflake&amp;utm_campaign=Badge_Grade)
[![NuGet](https://img.shields.io/nuget/v/MiffyLiye.Snowflake.svg?style=flat-square)](https://www.nuget.org/packages/MiffyLiye.Snowflake/)
[![Libraries.io for GitHub](https://img.shields.io/librariesio/github/MiffyLiye/Snowflake.svg?style=flat-square)](https://libraries.io/github/MiffyLiye/Snowflake)
[![Platform](http://img.shields.io/badge/platform-Windows%20%7C%20macOS%20%7C%20Linux-blue.svg?style=flat-square)](http://www.microsoft.com/net/core/platform)

A simple ID generator inspired by Twitter's snowflake.

## ID properties
* 1 bit leading 0 to ensure the long number is positive 
* 41 bits for timestamp
* 10 bits for machine ID
* 12 bits random number
* ~1.6 ms timestamp precision
* ~114 years timestamp range
* generate 1 ID in less than 1 ms
* concurrently generate 4096 unique IDs in less than 1 s

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
