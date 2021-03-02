# Import json module
import json
#import googleimages
# from googleimages import fetch_image_urls

from some_function import get_google_images

# Get user data.

# Open the existing json file for loading into a variable
with open('form_input.json', 'r') as f:
  people = json.load(f)

# Print each property of the object
for person in people:
  print(person['Vorname'] ,person['Nachname'], person['Instagram'])

Form_name = person['Vorname'], person['Nachname']




# Download images from Google.

# Call the function and insert the Form_name data into it
get_google_images(Form_name)
