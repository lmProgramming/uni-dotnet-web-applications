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
  creatingNewArticle = false;

  onSelect(id : number) {
    this.currentId = id;
    this.currentArticle = this.articlesService.getArticle(id);
  }

  onArticleModifyStart() {
    this.creatingNewArticle = false;
    this.isArticleModifyOpen = true;
  }

  onArticleModifyCancel() {
    this.isArticleModifyOpen = false;
  }

  onArticleRemove() {
    this.articlesService.removeArticle(this.currentId!);
    this.currentId = undefined;
    this.currentArticle
  }

  onArticleAdd() {
    this.creatingNewArticle = true;
    this.currentArticle = { id: this.articlesService.getNextId(), name: '', category: 'fruit', price: 0, expirationDate: new Date(), quantity: 0, imageName: '' };
    this.isArticleModifyOpen = true;    
  }

  onArticleModifySave(modifyData: ArticleDto)
  {
    this.isArticleModifyOpen = false;

    var article: Article;
    if (this.creatingNewArticle) {
      article = { id: this.articlesService.getNextId(), name: '', category: "fruit", price: 0, expirationDate: null, quantity: 0, imageName: null };
    } else {
      article = this.articlesService.getArticle(this.currentId!);
    }
    
    article.name = modifyData.name;
    article.category = modifyData.category;
    article.price = modifyData.price;
    article.expirationDate = modifyData.expirationDate;
    article.quantity = modifyData.quantity;
    article.imageName = modifyData.imageName == "" ? null : modifyData.imageName;

    if (this.creatingNewArticle) {
      this.articlesService.addArticle(article);
      this.currentId = article.id;
    }

    this.currentArticle = this.articlesService.getArticle(this.currentId!);
  }
}
