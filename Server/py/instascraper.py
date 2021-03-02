$pip3 install instagram-scraper
$pip3 install instagram-scraper --upgrade
$pip3 install instagram-scraper==1.7.0

# Import json module
import json

# Open the existing json file for loading into a variable
with open('form_input.json', 'r') as f:
  people = json.load(f)

# Print each property of the object
for person in people:
  print(person['Vorname'] ,person['Nachname'], person['Instagram'])


!instagram-scraper ['Instagram']