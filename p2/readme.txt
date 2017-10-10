<ISTE 340 Project 2 Use a Lib (jQuery) to Consume a Web Service ReadMe>

Emergency Search Directory

URL:
http://people.rit.edu/jjw3782/340/p2/

What's worth noting:
All standard requirements for the project are completed with all functionalities handled by jQuery.


Use of AJAX to pull in data as well as at least 3 plug-ins used.


A map interface using Google Maps is included in the 'Locations' tab in addition to the plug-ins already used.
A bug: when combo box within 'Locations' tab is changed Google Map interface becomes blank...
How to fix: Google Map interface is actually just zoomed in by 100%, double right click to zoom out...


Comments for code functionality are in all code files for documentation and ease of tracking.


When information is clicked, tabs with all information is pulled up within a separate dialog box that contains all tabs.


Plug-ins used (also documented within main index.html file):
jquery-ui-1.10.3.custom.css (for professional graphics styling)

jquery-1.9.1.js (for general data functionality)

jquery-ui-1.10.3.custom.js (for tabs functionality)

For table styling:
demo_page.css
demo_table.css

jquery.dataTables.js (for data table functionality such as prev/next function)

nprogress.js (for progress functionality)

gmap3.js (for Google Map interface and its functionalities)


Further complexity added:
An added myFind function that is called to ensure that every tab except the 'General' tab will display 'no data' for the
users and not 'null'.