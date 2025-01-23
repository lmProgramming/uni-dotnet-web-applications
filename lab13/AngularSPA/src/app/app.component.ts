import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ArticleListComponent } from './components/article-list/article-list.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ArticleListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Articles Manager';
}