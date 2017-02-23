import sys

### leer la matriz numerica de una imagen guardada como archivo de texto
def ReadMatrix(RutaArchiTexto):

    ### leer todo el archivo
    TextoMatriz = open(RutaArchiTexto, "r")

    ### leer todos los valores numericos restantes
    NumVals = TextoMatriz.read().split('\n')

    TextoMatriz.close()

    return NumVals
 
### cambiar el valor de los pixeles segun la transformacion lineal
def LinealTransform( vectInt ):
    intencidadSalida = []
    ImMin = float( min (vectInt) )
    ImMax = float( max (vectInt) )
    
    print (ImMin)
    print (ImMax)

    for numero in vectInt:
        ajuste = 255*(   (numero - ImMin)/(ImMax - ImMin) )
        #ajInt = int( round (ajuste) )
        intencidadSalida.append( ajuste )

    return intencidadSalida


### hacer transformacion no lineal
def NonLinealTrans ( vectInt, vecIntEntrada, int_M, int_N ):
    intencidadSalida = []
    for numero in vecIntEntrada:

        pix = numero
        ajuste = round( (255.0/(int_M*int_N)) * vectInt[pix], 0 )
        #ajInt = int( round (ajuste) )
        intencidadSalida.append( ajuste )

    return intencidadSalida



## escribir en un archivo de texto la matriz tranformada
def EscribirMatrizNumericaLineal ( NombreArchivo, VectorSalidaLineal ):
    escritor  = open("TransLineal.txt", "w")
    for numero in VectorSalidaLineal:
        escritor.write( str(numero)+ ' ')
    escritor.close()

def EscribirMatrizNumericaNoLinl ( NombreArchivo, VectorSalidaNonLieneal ):
    escritor  = open("TransNonLineal.txt", "w")
    for numero in VectorSalidaNonLieneal:
        escritor.write( str(numero)+ ' ')
    escritor.close()

def DepurarLinea (VecEntradaTexto):

    salida = []

    for linea in VecEntradaTexto:
        lineaPura = linea.split(' ')
        lineaPura = lineaPura[0:len(lineaPura)-1]
        for numero in lineaPura:
            salida.append( int (numero) )

    return salida

def Histograma   (VectOriginal):

    histo = list( range(0,256) )

    for i in range(0,256):
        histo[i] = 0

    for numero in VectOriginal:
        histo[numero] += 1

    return histo    

def HistoAcum    (VectOriginal):
    hi = Histograma(VectOriginal)
    hc = list(range(0,256))

    for numero in hc:
        hc[numero] = 0
    
    for i in range(1,256):
        hc[i] = (hc[i-1] + hi[i])

    return hc


def main ():

    nombre = sys.argv[len(sys.argv) -1]
    ruta   = sys.argv[1]
    int_M = int(sys.argv[2])
    int_N = int(sys.argv[3])



    intencidadesEntrada = ReadMatrix(ruta)
    intencidadesEntrada = DepurarLinea(intencidadesEntrada)
    hiAcum = HistoAcum(intencidadesEntrada)

    intencidadLinealSalida = LinealTransform(intencidadesEntrada)
    intencidadNonLinealSal = NonLinealTrans(hiAcum,intencidadesEntrada,int_N,int_M)

    EscribirMatrizNumericaLineal(nombre,intencidadLinealSalida)
    EscribirMatrizNumericaNoLinl(nombre,intencidadNonLinealSal)
    raw_input("Transformacion lineal y no lineal completa")

main()