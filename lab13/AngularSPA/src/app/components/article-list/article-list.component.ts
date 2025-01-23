import { Component, inject, Input, signal } from '@angular/core';
import { ArticlesService } from '../../services/articles.service';
import { ArticleComponent } from '../article/article.component';
import { ArticleFullComponent } from '../article-full/article-full.component';
import { Article } from '../../models/article.model';
import { ArticleFormComponent } from '../article-form/article-form.component';

@Component({
  selector: 'app-article-list',
  imports: [ArticleComponent, ArticleFullComponent, ArticleFormComponent],
  templateUrl: './article-list.component.html',
  styleUrl: './article-list.component.css'
})
export class ArticleListComponent {
  public articlesService = inject(ArticlesService);
  public currentId?: number;
  public currentArticle?: Article;
  isArticleModifyOpen = false;

  onSelect(id : number) {
    this.currentId = id;
    this.currentArticle = this.articlesService.articles.find((article)=>article.id === id);
  }

  onArticleModifyStart() {
    this.isArticleModifyOpen = true;
    console.log("Modify article");
  }

  onArticleModifyCancel() {
    this.isArticleModifyOpen = false;
  }

  onArticleModifySave(modifyData: {name: string})
  {
    this.isArticleModifyOpen = false;
    var article = this.articlesService.getArticle(this.currentId!)
    article.name = modifyData.name;

    this.currentArticle = this.articlesService.getArticle(this.currentId!);
  }
}
