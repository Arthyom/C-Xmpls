public class Buffer {
	private char 	contenido;
	private boolean disponible = false;

	public Buffer ( ){

	}

	public synchronized char recoger( ){
		if ( disponible )
			disponible = false;
		return contenido;
	}
	return ('\n');

	public synchronized void poner ( char c ){
		contenido = c;
		disponible = true;
	}
}