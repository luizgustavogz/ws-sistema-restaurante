import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cozinha',
  standalone: true,
  imports: [],
  templateUrl: './cozinha.component.html',
  styleUrl: './cozinha.component.css'
})
export class CozinhaComponent implements OnInit {
  itemPedido: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.obterItensPedido();
  }

  obterItensPedido() {
    this.http.get<any[]>('https://localhost:44300/api/ItemPedido')
      .subscribe(data => {
        this.itemPedido = data;
      });
  }
}
