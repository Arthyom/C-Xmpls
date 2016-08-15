public class Buffer {
	private char 	contenido;
	private boolean disponible = false;

	public Buffer ( ){

	}

	public char recoger( ){
		if ( disponible )
			disponible = false;
		return contenido;
	}
	return ('\n');

	public void poner ( char c ){
		contenido = c;
		disponible = true;
	}
}