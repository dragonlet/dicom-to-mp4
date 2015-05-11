cmd.cs -- This file handles command line interface.


conv.cs -- This file is the backbone of the conversion process.
It contains the functionality that extracts the individual images from the dicom files.
Currently it only supports up to 9,999 frames.
It interfaces with NReco and performs the actual conversion from png files to mp4.

dicom.cs -- This file contains the dcm class, which handles tag extraction from the dicom files.
This class also handles the display names on the dicom select list by the overloaded ToString func.

Form1.cs -- This is the main display form. It is laid out using a table and currently has 3 main elements.
Element 1: The dicom select list is populated given a preset path. The files in the path then get passed to the Dicom class to grab info and make the names displayed.
Element 2: The movie file list is populated with the contents of the output file from the conversion function.
Element 3: The drive list is populated with all removable drives currently registered by the system.
	The entire system tree is not allowed for saving due to potential security concerns and potential lack of access to system internals for users.

Form2.cs -- This is for the progress bar?

gui.cs -- This file handles all of the helper functions that are used in Form1 but that don't immediately access the elements of Form1.
This is designed so it can be swapped out more easily (moreso that Form1 can be redesigned more easily).

popup.cs -- This is a wrapper for C# MessageBox functionality.

program.cs -- This is what makes the program run. It is needed for CLI functionality as well as form functionality.

sys.cs -- This contains most of the super backend things such as file system management through windows (creating, deleting files, scanning directories, etc.)

