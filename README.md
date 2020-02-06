# FamilyScoreboard
Keeping track of what family members accomplished around the house

## Prerequisites
- Docker

Setup to run:
- clone the repository
- docker-compose up --build
- browse to http://localhost:5000 to confirm
- from other devices on the network, the app should be reachable at http://{hostMachineIp}:5000
  
## How Do I use this?
### Landing Page
The landing page will evolve into a dashboard. At the moment, it doesn't display much. Once the rest of the functionality is built, this will come to life.


### Family Managment
From the Family Page, All family members are displayed in cards at the top. Clicking the Eye icon will take you to a details view. Clicking the Trash can will remove the given family member.

The Add New Family Memeber button will reveal a form where new family member information can be entered.

### Family Member Details
The Family Member Details view will list a given members current points balance, and display lists of the chores they've completed, along with the rewards they have redeemed.

To award a family member with a completed chore, select the chore from the dropdown, then click the Mark Complete button.

### Chore Managment
From the Chores Page, All chores will be displayed on cards at the top. Clicking the trash can on any given chore will remove it.

The Add New Chore button will reveal a form where new chores can be added.

### Reward Management
The reward management page has not yet been built. Expect it to resemble the Chore Management Page
