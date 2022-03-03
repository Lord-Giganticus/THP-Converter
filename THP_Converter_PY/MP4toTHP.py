import sys, os, argparse
parser = argparse.ArgumentParser()
parser.add_argument("-in","--infile",type=str,required=True,help="The mp4 file to turn into a thp file.")
parser.add_argument("-r","--rate",type=float,required=True,help="The frame rate the thp video will be.")
parser.add_argument("-out","--outfile",type=str,required=True,help="The ouptut THP file.")
def main():
    args = parser.parse_args()
    file = args.infile
    rate = args.rate
    out_file = args.outfile
    if os.path.isfile(file) == False:
        raise FileNotFoundError
    if os.path.isfile(out_file) == True:
        raise FileExistsError
    os.system('cmd /c ffmpeg -i "'+file+'" -r '+str(rate)+' -qscale:v 2 frame%05d.jpg')
    os.system('cmd /c thpconv -j *.jpg -d "'+out_file+'"')
    os.system('cmd /c del /f *.jpg')
    print("Complete.")
    return

if __name__ == '__main__':
    exit(main())