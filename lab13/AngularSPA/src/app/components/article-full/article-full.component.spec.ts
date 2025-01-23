import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleFullComponent } from './article-full.component';

describe('ArticleFullComponent', () => {
  let component: ArticleFullComponent;
  let fixture: ComponentFixture<ArticleFullComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArticleFullComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArticleFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
