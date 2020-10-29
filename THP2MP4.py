import os

program_location = os.getcwd()

THP_Location = input("Please input the folder of thp vids you wish to convert:")
os.chdir(THP_Location)
print(os.getcwd())
input("If this is not the correct folder I swear...")

for name in os.listdir('.'):
    if name.endswith('.thp') == False:
        input("There are no thp files here! Press enter to exit and next time choose the right folder.")
        exit()

THP_Conv = open('THPconv.bat', 'w')
THP_Conv.write('for %%a in ("*.thp") do ffmpeg -i "%%a" "%%~na.mp4"')
THP_Conv.close()

os.system('cmd /c THPconv.bat')
os.system('cmd /c del /f *bat')

print("Do you wish to rerun this in another folder? If so, type the corresponding number to your choice. \n [1] Yes \n [2] No.")
Rerun_Program = input()

if Rerun_Program == "1":
    os.chdir(program_location)
    os.system('cmd /c py -3 THP2MP4.py')
elif Rerun_Program == "2":
    exit()
else:
    input("Whoops! That wasn't supposed to happen! Press enter to exit.")
    exit()
