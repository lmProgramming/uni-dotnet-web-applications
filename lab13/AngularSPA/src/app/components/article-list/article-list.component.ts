import { Component, inject, Input, signal } from '@angular/core';
import { ArticlesService } from '../../services/articles.service';
import { ArticleComponent } from '../article/article.component';
import { ArticleFullComponent } from '../article-full/article-full.component';
import { Article, ArticleDto } from '../../models/article.model';
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
    this.currentArticle = this.articlesService.getArticle(id);
  }

  onArticleModifyStart() {
    this.isArticleModifyOpen = true;
    console.log("Modify article");
  }

  onArticleModifyCancel() {
    console.log("Cancel modify article");
    this.isArticleModifyOpen = false;
  }

  onArticleRemove() {
    this.articlesService.removeArticle(this.currentId!);
    this.currentId = undefined;
    this.currentArticle
  }

  onArticleAdd() {
    this.isArticleModifyOpen = true;
    
  }

  onArticleModifySave(modifyData: ArticleDto)
  {
    this.isArticleModifyOpen = false;
    var article = this.articlesService.getArticle(this.currentId!)
    article.name = modifyData.name;
    article.category = modifyData.category;
    article.price = modifyData.price;
    article.expirationDate = modifyData.expirationDate;
    article.quantity = modifyData.quantity;
    article.imageName = modifyData.imageName;

    this.currentArticle = this.articlesService.getArticle(this.currentId!);
  }
}
