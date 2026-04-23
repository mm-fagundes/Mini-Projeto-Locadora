    var locadora = new Locadora();
    var filme1 = new Filme("Interstellar" , "Filme espacial" , 2007, Genero.Scifi,"Nolan", 180);
    var serie1 = new Serie("Suits" , "Serie de advogado", 2012, Genero.Drama,29, 9);


    locadora.AdicionarTitulo(filme1);
    locadora.AdicionarTitulo(serie1);
    locadora.ListarTitulos();
    locadora.BuscarPorAno();


