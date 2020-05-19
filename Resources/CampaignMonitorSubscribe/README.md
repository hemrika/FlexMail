# Campaign Monitor Subscribe Kentico Web Part

## Before Installing
Ensure that you have installed the nuget package for Campaign Monitor's API.  Without this the Web Part will not function.

    PM> Install-Package campaignmonitor-api

## Installation - Website Project
1. Download and extract the zip file.
2. Use Kentico's object import to import the file `CampaignMonitorSubscribe_Website.zip`.
3. In step 2 of the import process ensure that you check the box to "Import code files".
4. Once the import is complete, you will need to resign macros as some of the web part properties use macros to determine visibility.  See https://docs.kentico.com/display/K9/Importing+a+site+or+objects#Importingasiteorobjects-Re-signingimportedmacroexpressions for more information.

## Installation - Web Application Project
Install as for a website project above, then follow the instructions at https://docs.kentico.com/display/K9/Importing+to+web+application+projects

## Configuration
1. Add the `Campaign Monitor Subscribe` web part to one of your pages.
2. In the Web Part Configuration ensure that you have filled in the required fields and the "Campaign Monitor" section as a minimum.

That's all there is to it.

## Google Analytics
If you have Google Analytics already present in the page on which the web part will be displayed you can enable Google Analytics support in the Web Part configuration.

Here you have the option to specify the "event" details for Google Analytics.  These will be sent to Google Analytics on a **successful** registration.

## EMS / Online Marketing
If you have a Kentico EMS license the web part will automatically update the current contact with name and email address information when they submit the form, irrespective of whether the push to Campaign Monitor is successful.

If you specify a contact group in the Web Part Configuration the contact will also be added to this group.

If you specify a Conversion in the Web Part Configuration then that conversion will be triggered only on a successfull registration of details with Campaign Monitor.

## FAQ
**Q: Where do I find my Campaign Monitor List ID**  
*A: Under "Lists & Subscribers" click on the list you'd like to use, then click on the "change name/type" link below the lists name.  The List ID is listed below the heading "API Subscriber List ID"*

