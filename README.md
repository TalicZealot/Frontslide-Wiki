# Frontslide-Wiki  ![SotnWiki](https://raw.githubusercontent.com/TalicZealot/Frontslide-Wiki/master/SotnWiki/SotnWiki.WebFormsClient/Content/richter.png "SotnWiki")


# Concept

A lightweight wiki-like web app

* Public content submission and editing based on a light markup format (Texstyle)
* Moderation functionality to review and publish submissions and edits
* Authentication exclusively through Twitter for ease of use and security (Identity/Oauth)

* **Implemented with the purpose of beinmg a wiki for the Castlevania: Symphony of the Night speedrunning community**
  * Automatic backup of speedrun.com leaderboard
  * Dynamic world record display in category pages
  * Archive of the old leaderboard

# Technical

* Etity Framework code first database
* Abstract data layer through a generic repository
* Services for data, authentication and text encoding
* Initial implementation with ASP.NET WebForms client using MVP architectural pattern
* Reimplemented with ASP.NET MVC5
* High code coverage unit tests
* Integration tested