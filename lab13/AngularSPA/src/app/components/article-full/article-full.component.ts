import { Component, input, output, computed } from '@angular/core';
import { Article } from '../../models/article.model';

@Component({
  selector: 'app-article-full',
  imports: [],
  templateUrl: './article-full.component.html',
  styleUrl: './article-full.component.css'
})
export class ArticleFullComponent {
  article = input.required<Article>();

  modifyPress = output();
  removePress = output();

  imagePath = computed(() => `assets/images/${this.article().imageName?? "default.png"}`);

  onModify(){
    this.modifyPress.emit();
  }

  onRemove() {
    this.removePress.emit();
  }
}
