T-SQL Flex
==========

T-SQL Flex is a scripting productivity tool for SQL Server Management Studio that uses the Red Gate SIP Framework.

*This is alpha-quality software - DO NOT RUN IN PRODUCTION!!!*

T-SQL Flex can script out the returned schema and data of any T-SQL query simply and with high accuracy.  It can also export the data to the XML spreadsheet format which can be opened in Excel without having messed-up date formatting or losing leading zeros; multiple result sets are automatically placed on multiple worksheets.  Much more is planned.






**To install T-SQL Flex:**
  * Download the latest release from the [GitHub releases page](https://github.com/nycdotnet/TSqlFlex/releases).
  * Install the [Red Gate SIP framework](http://documentation.red-gate.com/display/MA/Redistributing+the+framework).
  * Create a new registry string value (REG_SZ) in the appropriate location to point to the extracted TSQLFlex.dll:

|Architecture|Registry Value Location|
|----|-----|
|32-bit Windows|HKLM\SOFTWARE\Red Gate\SIPFramework\Plugins|
|64-bit Windows|HKLM\SOFTWARE\Wow6432Node\Red Gate\SIPFramework\Plugins|
*Example: name = "TSQLFlex", value = "C:\ExtractedFiles\TSqlFlex.dll"*
  * Launch SQL Server Management Studio and click the T-SQL Flex button.
  * Fix the window positioning (will be better in next release).
  * Type one or more queries in the top panel and click the Run'n'Rollback button.  T-SQL Flex will run your query in the scope of an ADO.NET Transaction that is rolled-back when the batch completes.  The schema returned from those queries will be scripted in the lower panel.

**To uninstall T-SQL Flex:**
  * Simply delete the registry key and the extracted files and restart SSMS.

Please create issues on GitHub or reach out to Steve on Twitter at [@nycdotnet](https://twitter.com/nycdotnet).

**Patch notes:**
  * v0.0.5-alpha (2014-08-22):
      * Export to "XML Spreadsheet 2003" functionality added - this is very early alpha for this feature.
      * Started significant refactoring effort for data scripting in T-SQL field vs general presentation.
      * Started work to use a file stream rather than a string builder for scripting the data.  Currently only used with the Excel XML export.
  * v0.0.4-alpha (2014-06-18):
      * Converted to background worker.  Added cancel button, timer, and progress bar.
	  * Additional scripted output "minification" improvements (dropping insignificant decimals for example).
	  * Other improvements to quality of scripted output such as bracketing of keywords.
  * v0.0.3-alpha (2014-06-13): Fixed data script escaping bug for single quotes.
  * v0.0.2-alpha (2014-06-11): Data scripting implemented.  Improved window.
  * v0.0.1-alpha (2014-06-01): Initial release.  Schema scripting working.

**Debugging an add-in:**
  * See the Red Gate document on this issue: http://documentation.red-gate.com/display/MA/Debugging+an+SSMS+addin


**Build checklist**
  * Compiles and all tests pass.
  * Checked-in to master branch on GitHub.
  * Updated assembly revisions.
  * Build in release mode and test it out.
  * Zip up the three DLLs and post to GitHub.
  * Add a screenshot via GitHub and edit the README and release FAQ.