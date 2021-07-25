import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Evento } from '../model/evento.vm';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  widthImg: number = 150;
  marginImg: number = 2;
  isCollapsed: boolean = false;
  private _filtro: string = '';


  public get filtro():string{
    return this._filtro;
  }

  public set filtro(value: string){
    this._filtro = value;
    this.eventosFiltrados = this.filtro ? this.filtrarEventos(this.filtro) : this.eventos;
  }

  filtrarEventos(filtrarPor: string):Evento[]{

    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1);
  }


  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos():void {

    this.http.get<Evento[]>("https://localhost:5001/api/evento")
    .subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
        console.log(response);

      },
      error => console.log(error)
    );
  }
}
