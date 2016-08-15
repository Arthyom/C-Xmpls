import pc;

public static void main(String[] args) {
	
	Buffer b = new Buffer();

	Productor 	p = new Productor();
	Consumidor	c = new Consumidor();

	p.Start();
	c.Start();

	

}