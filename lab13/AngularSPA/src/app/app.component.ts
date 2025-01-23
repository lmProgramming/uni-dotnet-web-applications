import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ArticleListComponent } from './components/article-list/article-list.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ArticleListComponent, HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Articles Manager';
}