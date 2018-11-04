# NclArchive

API for [NCL Archive](http://www.nclarchive.co.uk).

[Postman queries](https://github.com/jmkapp/NclArchive/tree/master/Postman).

The following files are excluded by `gitignore` for security reasons and need to exist in the same directory as `web.config`:

`AppSettings.config`:

`<appSettings>
  <add key="ApiPassword" value="{api password}"/>
</appSettings>`

`ConnectionString.config`:

`<connectionStrings>
  <add name="NclArchive" connectionString="{connection string}" />
</connectionStrings>`

