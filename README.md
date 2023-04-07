# xToolMerge

A command line utility that takes two XTool XCS files and output them as a merged single file leaving the original un-changed.

This is very beta, please backup your files first.

## Usage
You'll need two files generated by xTool Creative Space.

For example here are two files that you may want combined into one:
![image](https://user-images.githubusercontent.com/4653907/230638300-5788280d-529b-4594-9fdb-df9374ba8f81.png)
![image](https://user-images.githubusercontent.com/4653907/230638332-7d8e853b-9214-4b3c-a98b-192762791c07.png)

To merge:
1. Open a command prompt
2. Navigate to your `xToolMerge` directory
3. Enter a command like the following example:

`xtoolmerge --sourceFile1 C:\Users\kevin\Desktop\Output.xcs --sourceFile2 C:\Users\kevin\Desktop\Luke-Saber-NewHope.xcs --outputFilename c:\Users\kevin\Desktop\output.xcs`

![image](https://user-images.githubusercontent.com/4653907/230638537-4ed50845-743b-4d17-b8bb-33bc29604354.png)

All arguments are required.

Upon sucess you'll have a new file ready to open:

![image](https://user-images.githubusercontent.com/4653907/230638866-42529f99-eacb-435f-bc53-916cf56869b7.png)
![image](https://user-images.githubusercontent.com/4653907/230639284-4a44d3f2-ada0-475b-9a31-0a08b83fce01.png)
![image](https://user-images.githubusercontent.com/4653907/230638934-d8828244-f7a3-47bc-bdb3-aabc8483d1b4.png)

## Arguments

`--sourceFile1` - The file we will add to.
`--sourceFile2` - The file we will pull models from.
`--outputFilename` - The file that will be created. Please be careful as this will overwrite any existing file.

If you'd like to keep adding models to one file, make the `--sourceFile1` and `--outputFilename` the same name.

## Install
Dotnet 6.0+ is required. This might work on a Mac, I have no idea.

Simply download [the ZIP in the release section](https://github.com/kgiszewski/xToolMerge/releases) and put it where you'd like.

Follow the usage section above.

## Known Issues
If the `Process` button fails to work, go thru each layer ensuring the material, power and speed are set on each imported layer.

## License
MIT License

## Contributing
Are you a coder? Send a PR.

Are you just wanting bugs fixed and want to appreciate the contributors? We'd love it if you'd buy a support token (or as many as you'd like): https://www.etsy.com/listing/1442399906/xtoolmerge-support-token
