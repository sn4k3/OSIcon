# v3.0

* Rewrite the code for better performance and usage
* Added a FileExplorer control that behaves like the windows explorer
* Added a strong key to the library
* Library is now compiled with .NET Framework 4.0

# v2.0

* Added About class
* Added better commentaries
* Added more samples
* Updated the sample application to use new icon sizes
* Updated the sample application to use the new library
* IconProperties class
  * Added the "Remove" function, to remove an icon from a specified size
  * Supports multi sizes flags (IconReader.IconSize.Small | IconReader.IconSize.Large)
  * Returns a Dictionary<IconReader.IconSize, int> with removed icons, where int is the icon index on the ImageList
  * Added three "IsValid" functions
  * bool IsValidEx(IconReader.IconSize size), same as "IsValid(IconReader.IconSize size)", but also checks if the icon is not NULL
  * bool IsValid(), checks if that instance contains an icon
  * bool IsValid(IconReader.IconSize size), checks if an icon of a specified size exists in that instance
  * Changed "IconsInfo" type from struct to Dictionary<IconReader.IconSize, Shell32.SHFILEINFO>
  * Changed "IconsIndex" type from struct to Dictionary<IconReader.IconSize, int>
  * Changed "Icons" type from struct to Dictionary<IconReader.IconSize, Icon>
  * Implemented a "Tag" object
  * Disposable class
  * "IconProperties" is now a class, was a struct before
* IconManager class
  * Fixed the "AddEx" function to allow adding more icons of different sizes
  * Added commentaries
  * Added two "Remove" functions, allows removing icons from the cache and from the ImageList
  * bool Remove(string path, bool removeIconFromList), removes all icons
  * bool Remove(string path, IconReader.IconSize iconSize, bool removeIconFromList), removes icons of a specified size only
  * Added private "Add" function, common actions when adding icons to list (to remove redundancy)
  * Added "IsValidEx" function, same as "IsValid", but returns the matched "IconProperties"; otherwise returns a new instance
  * Added two new constructors
  * public IconManager(bool createSmallIconList, bool createLargeIconList, bool createExtraLargeIconList, bool createJumboIconList)
  * public IconManager(bool createSmallIconList, bool createLargeIconList, bool createExtraLargeIconList, bool createJumboIconList, bool optimizeToOS)
  * Replaced "ImageListSmall" and "ImageListLarge" ImageLists with "IImageList" Dictionary<IconReader.IconSize, ImageList>
  * Added "IconSizeAllSupported" readeonly variable, contains all icon sizes supported by the current OS
  * Added "IconManager.IconSizeAll" constant, contains all icon sizes (Small | Large | ExtraLarge | Jumbo)
* IconReader class
  * Changed all functions that contain a "IconReader.IconSize" to support new icon sizes (ExtraLarge, Jumbo)
  * Added the "ExtractIconFromResource" function, extracts an icon by name from the assembly
  * Added the "ExtractIconsFromFile" function, extracts all icons from a file; returns "Icon[]"
  * Added the "ExtractIconFromFileEx" function, identical to ExtractIconFromFile, but supports bigger sizes and icon information
  * Added two new icon sizes to "IconReader.IconSize"
  * IconReader.Iconsize.ExtraLarge (48x48 px.), XP or above supported
  * IconReader.Iconsize.Jumbo (256x256 px.), Vista or above supported
  * Renamed function "ExtractIcon" to "ExtractIconFromFile"
* About class
  * Added the "ProjectAuthor" constant, my name
  * Added the "ProjecWWW" constant, this page URL

# v1.0.01

* Modified to correct egregious formatting and spelling errors - JSOP - 01/03/2010

# v1.0

* First release.