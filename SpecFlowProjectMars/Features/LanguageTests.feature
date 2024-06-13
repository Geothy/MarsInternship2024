Feature:Test scenarios for Language tab
1. Add Language
2. Edit Language
3. Delete Language

Scenario Outline:A.Verify user is able to add language in Languages tab in the profile page
Given user logs into Mars Portal
And navigates to Languages tab in Profile Page
When user enters Language "<Language>" and Language Level "<Level>"
Then the language "<Language>" should be added to Languages tab in Profile Page

Examples: 
| Language      | Level  |
| English       |        |
| 123Mara+++thi | Basic  |
|               |        |
|               | Basic  |
| Malayalam     | Fluent |

Scenario Outline:B.Verify user is able to edit language in Languages tab in the profile page
Given user logs into Mars Portal
And navigates to Languages tab in Profile Page
When user edits Language "<Language>" and Language Level "<Level>"
Then the language "<Language>" should be edited into Languages tab in Profile Page
Examples: 
| Language | Level  |
| Marathi  | Basic  |
|          | Basic  |
| Hindi    | Fluent |

Scenario Outline:C.Verify user is able to delete language in Languages tab in the profile page
Given user logs into Mars Portal
And navigates to Languages tab in Profile Page
When user deletes the Language "<Language>"
Then the language "<Language>" should be deleted from Languages tab in Profile Page
Examples: 
| Language | Level  |
| Hindi    | Fluent |

