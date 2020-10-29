import os

program_location = os.getcwd()

MP4_Location = input("Please input the folder where ONE mp4 video is:")
os.chdir(MP4_Location)
print(os.getcwd())
input("If this is not the correct folder I swear...")

for name in os.listdir('.'):
    if name.endswith('.mp4') == False:
        input("There are no mp4 files here! Press enter to exit and next time choose the right folder.")
        exit()

print("Not all THP videos have audio. Do you wish to have audio for yours? Then type the corresponding number to your choice.\n[1] Yes\n[2] No")
Audio = input("")

if Audio == "1":
    wav_conv = open('wavconv.bat','w')
    wav_conv.write('for %%a in ("*.mp4") do ffmpeg -i "%%a" "input.wav"')
    wav_conv.close()

    MP4_Conv = open('MP4toTHP.bat', 'w')
    MP4_Conv.write('for %%a in ("*.mp4") do ffmpeg -i "%%a" "input.mp4"')
    MP4_Conv.close()

    os.system('cmd /c wavconv.bat')
    os.system('cmd /c MP4toTHP.bat')
    os.system('cmd /c ffmpeg -i input.mp4 -r 30 frame%03d.jpg')
    os.system('cmd /c thpconv -j *.jpg -s input.wav -d output.thp')
    os.system('cmd /c del /f *.bat')
    os.system('cmd /c del /f *.wav')
    os.system('cmd /c del /f *.jpg')
    os.system('cmd /c del /f input.mp4')

    print("Do you wish to rerun the program? If so type the corresponding number to your choice.\n [1] Yes\n [2] No")
    rerun = input("")

    if rerun == "1":
        os.chdir(program_location)
        os.system('cmd /c py -3 MP4toTHP.py')
    elif rerun == "2":
        exit()
    else:
        input("Whoops! That wasn't supposed to happen! Press enter to exit.")
        exit()      
elif Audio == "2":
    MP4_Conv = open('MP4toTHP.bat', 'w')
    MP4_Conv.write('for %%a in ("*.mp4") do ffmpeg -i "%%a" "input.mp4"')
    MP4_Conv.close()

    os.system('cmd /c MP4toTHP.bat')
    os.system('cmd /c del /f *.bat')
    os.system('cmd /c ffmpeg -i input.mp4 -r 30 frame%03d.jpg')
    os.system('cmd /c thpconv -j *.jpg -d output.thp')
    os.system('cmd /c del /f *.jpg')
    os.system('cmd /c del /f input.mp4')


    print("Do you wish to rerun the program? If so type the corresponding number to your choice.\n [1] Yes\n [2] No")
    rerun = input("")

    if rerun == "1":
        os.chdir(program_location)
        os.system('cmd /c py -3 MP4toTHP.py')
    elif rerun == "2":
        exit()
    else:
        input("Whoops! That wasn't supposed to happen! Press enter to exit.")
        exit()    
else:
    input("Whoops! That wasn't supposed to happen Press enter to exit.")
    exit()