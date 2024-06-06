Feature:Test scenarios for Skills tab
1. Adding Skills
2. Editing Skills
3. Deleting Skills

Scenario Outline:A.Verify user is able to add Skill in Skills tab in the profile page
Given User logs into Mars Portal
And navigates to Skills tab in Profile Page
When user enters Skill "<Skill>" and Skill Level "<Level>"
Then the Skill "<Skill>" should be added to Skills tab in Profile Page
Examples: 
| Skill        | Level    |
| Multitasking | Intermediate |
| Or123on      | Beginner |



Scenario:B.Verify user is able to edit Skill in Skills tab in the profile page
Given User logs into Mars Portal
And navigates to Skills tab in Profile Page
When user edits Skill and Skill Level
Then the Skill should be updated to Skills tab in Profile Page

Scenario:C.Verify user is able to delete Skill in Skills tab in the profile page
Given User logs into Mars Portal
And navigates to Skills tab in Profile Page
When user deletes Skill 
Then the Skill should be deleted from Skills tab in Profile Page
