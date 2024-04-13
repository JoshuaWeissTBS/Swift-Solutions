Feature: Bookmark Lists

This story involves expanding the functionality of the favorites feature to allow for saving events into specific user-created lists. This story does not include removing or modifying the contents of the new bookmark lists or the bookmark lists themselves.

Background:
	Given the following users exist
	  | UserName         | Email                 | FirstName  | LastName | Password  |
	  | Joshua Weiss     | knott@example.com     | Joshua     | Weiss    | FAKE PW   |

Scenario: There is a bookmark list and a way to add a new bookmark list on the favorites page
	Given I am a user with first name 'Joshua'
	 And  I login
	When I am on the "Favorites" page
	Then I should see a bookmark list
	 And I should see a way to create a new bookmark list
