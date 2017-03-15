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

* Initial implementation with ASP.NET WebForms client using MVP architectural pattern
* Reimplemented with ASP.NET MVC5


* Dependency inversion through depencency injection
* Automatic unit testing, local deployment and integration testing through Jenkins
* Automatic daily backups of the runs on speedrun.com/sotn