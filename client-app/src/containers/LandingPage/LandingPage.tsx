import React from "react";
import { Button, Header } from "semantic-ui-react";
import ImageSlider from "../../components/ImageSlider/ImageSlider";
import HomerImage from "../../assets/homersimpson.0.0.jpg";

import "./LandingPage.scss";

type LandingPageType = {};

const LandingPage: React.FC<LandingPageType> = (props) => {
  return (
    <div className="landing-page">
      <div className="landing-page__social-proof">
        <div className="landing-page__social-proof__section">
          <h1 className="landing-page__social-proof__section__headline">
            HEADLINE
          </h1>
          <h3 className="landing-page__social-proof__section__subtitle">
            Subtitle
          </h3>
          <div className="landing-page__social-proof__section__buttons-container">
            <Button className="landing-page__social-proof__section__buttons-container__button">
              Start learning
            </Button>
            <Button className="landing-page__social-proof__section__buttons-container__button">
              Start sharing passion
            </Button>
          </div>
        </div>
        <div className="landing-page__social-proof__visuals">
          <div className="landing-page__social-proof__visuals__container"></div>
        </div>
      </div>
      <div className="landing-page__experience">
        <div className="landing-page__experience__title">
          What you will experience
        </div>
        <div className="landing-page__experience__row">
          <div className="landing-page__experience__row__section">
            <div className="landing-page__experience__row__section__header">
              <img
                src={HomerImage}
                className="landing-page__experience__row__section__header__image"
              />
              <div className="landing-page__experience__row__section__header__title">
                Benefit #1
              </div>
            </div>
            <div className="landing-page__experience__row__section__body">
              In tristique porttitor lacus sed hendrerit. Nulla ipsum velit,
              porta eget euismod eget, lobortis at ante. Phasellus facilisis
              volutpat enim id ullamcorper. Ut pharetra neque ut orci lobortis
              iaculis. Nam pretium at ipsum ut ultrices. Ut non sem ut purus
              cursus cursus ac nec nulla. Suspendisse ornare maximus ligula
              vitae vulputate.
            </div>
          </div>
          <div className="landing-page__experience__row__section">
            <div className="landing-page__experience__row__section__header">
              <img
                src={HomerImage}
                className="landing-page__experience__row__section__header__image"
              />
              <div className="landing-page__experience__row__section__header__title">
                Benefit #2
              </div>
            </div>
            <div className="landing-page__experience__row__section__body">
              Nunc eu fermentum elit. Nam pretium fringilla leo, eu rutrum erat
              lobortis tempor. Nullam ac ante ante. Nunc nisl ligula, suscipit
              ac dictum ac, suscipit a turpis. Pellentesque egestas felis elit,
              ut vehicula nisl accumsan sed. Proin iaculis pharetra luctus.
              Donec non velit a turpis tristique interdum a sed ipsum.
            </div>
          </div>
        </div>
        <div className="landing-page__experience__row">
          <div className="landing-page__experience__row__section">
            <div className="landing-page__experience__row__section__header">
              <img
                src={HomerImage}
                className="landing-page__experience__row__section__header__image"
              />
              <div className="landing-page__experience__row__section__header__title">
                Benefit #3
              </div>
            </div>
            <div className="landing-page__experience__row__section__body">
              In tristique porttitor lacus sed hendrerit. Nulla ipsum velit,
              porta eget euismod eget, lobortis at ante. Phasellus facilisis
              volutpat enim id ullamcorper. Ut pharetra neque ut orci lobortis
              iaculis. Nam pretium at ipsum ut ultrices. Ut non sem ut purus
              cursus cursus ac nec nulla. Suspendisse ornare maximus ligula
              vitae vulputate.
            </div>
          </div>
          <div className="landing-page__experience__row__section">
            <div className="landing-page__experience__row__section__header">
              <img
                src={HomerImage}
                className="landing-page__experience__row__section__header__image"
              />
              <div className="landing-page__experience__row__section__header__title">
                Benefit #4
              </div>
            </div>
            <div className="landing-page__experience__row__section__body">
              Nunc eu fermentum elit. Nam pretium fringilla leo, eu rutrum erat
              lobortis tempor. Nullam ac ante ante. Nunc nisl ligula, suscipit
              ac dictum ac, suscipit a turpis. Pellentesque egestas felis elit,
              ut vehicula nisl accumsan sed. Proin iaculis pharetra luctus.
              Donec non velit a turpis tristique interdum a sed ipsum. Vivamus
              eget malesuada neque.
            </div>
          </div>
        </div>
      </div>
      <div className="landing-page__says">
        <div className="landing-page__says__container">
          <div className="landing-page__says__container__section__title-main">
            What clients says
          </div>
          <div className="landing-page__says__container__section">
            <div className="landing-page__says__container__section__title">
              Stefan
            </div>
            <div className="landing-page__says__container__section__description">
              Proin quis lacus elit. Vestibulum suscipit molestie tortor vitae
              suscipit. Nunc cursus elit dui, et sagittis urna ullamcorper sit
              amet. Sed condimentum mi eget orci tincidunt, vestibulum
              consectetur arcu scelerisque. Cras ut malesuada nisl. Praesent
              rutrum arcu et orci blandit viverra at eu magna. Nam tempor dolor
              lorem. Integer ut diam molestie, mattis arcu a, fermentum elit.
              Suspendisse vehicula, nibh sit amet auctor bibendum, eros odio
              suscipit erat, ut fringilla nunc eros sit amet nulla.
            </div>
          </div>
        </div>
        <div className="landing-page__says__container">
          <div className="landing-page__says__container__section__title-main">
            What consultants says
          </div>
          <div className="landing-page__says__container__section">
            <div className="landing-page__says__container__section__title">
              Krstic
            </div>
            <div className="landing-page__says__container__section__description">
              Proin quis lacus elit. Vestibulum suscipit molestie tortor vitae
              suscipit. Nunc cursus elit dui, et sagittis urna ullamcorper sit
              amet. Sed condimentum mi eget orci tincidunt, vestibulum
              consectetur arcu scelerisque. Cras ut malesuada nisl. Praesent
              rutrum arcu et orci blandit viverra at eu magna. Nam tempor dolor
              lorem. Integer ut diam molestie, mattis arcu a, fermentum elit.
              Suspendisse vehicula, nibh sit amet auctor bibendum, eros odio
              suscipit erat, ut fringilla nunc eros sit amet nulla.
            </div>
          </div>
        </div>
      </div>
      <div className="landing-page__faq">
        <div className="landing-page__faq__title">
          Frequently asked questions
        </div>
        <div className="landing-page__faq__question">
          <div className="landing-page__faq__question__title">FAQ #1</div>
          <div className="landing-page__faq__question__answer">
            Nunc eu fermentum elit. Nam pretium fringilla leo, eu rutrum erat
            lobortis tempor. Nullam ac ante ante. Nunc nisl ligula, suscipit ac
            dictum ac, suscipit a turpis. Pellentesque egestas felis elit, ut
            vehicula nisl accumsan sed. Proin iaculis pharetra luctus. Donec non
            velit a turpis tristique interdum a sed ipsum.
          </div>
        </div>
        <div className="landing-page__faq__question">
          <div className="landing-page__faq__question__title">FAQ #2</div>
          <div className="landing-page__faq__question__answer">
            Nunc eu fermentum elit. Nam pretium fringilla leo, eu rutrum erat
            lobortis tempor. Nullam ac ante ante. Nunc nisl ligula, suscipit ac
            dictum ac, suscipit a turpis. Pellentesque egestas felis elit, ut
            vehicula nisl accumsan sed. Proin iaculis pharetra luctus. Donec non
            velit a turpis tristique interdum a sed ipsum.
          </div>
        </div>
        <div className="landing-page__faq__question">
          <div className="landing-page__faq__question__title">FAQ #3</div>
          <div className="landing-page__faq__question__answer">
            Nunc eu fermentum elit. Nam pretium fringilla leo, eu rutrum erat
            lobortis tempor. Nullam ac ante ante. Nunc nisl ligula, suscipit ac
            dictum ac, suscipit a turpis. Pellentesque egestas felis elit, ut
            vehicula nisl accumsan sed. Proin iaculis pharetra luctus. Donec non
            velit a turpis tristique interdum a sed ipsum.
          </div>
        </div>
        <div className="landing-page__faq__question">
          <div className="landing-page__faq__question__title">FAQ #4</div>
          <div className="landing-page__faq__question__answer">
            Nunc eu fermentum elit. Nam pretium fringilla leo, eu rutrum erat
            lobortis tempor. Nullam ac ante ante. Nunc nisl ligula, suscipit ac
            dictum ac, suscipit a turpis. Pellentesque egestas felis elit, ut
            vehicula nisl accumsan sed. Proin iaculis pharetra luctus. Donec non
            velit a turpis tristique interdum a sed ipsum.
          </div>
        </div>
      </div>
      <div className="landing-page__cta">
        <div className="landing-page__cta__title">
          Learn/Consult in fields such as
        </div>
        <div>
          <ImageSlider
            images={[
              { path: HomerImage, text: "Marketing and Design" },
              { path: HomerImage, text: "IT/Computer Science" },
              { path: HomerImage, text: "Psychotherapy" },
            ]}
            sliderClassName="landing-page__cta__slider"
            containerClassName="landing-page__cta__slider__container"
            imageClassName="landing-page__cta__slider__container__image"
            textClassName="landing-page__cta__slider__container__text"
          />
        </div>
      </div>
      <div className="landing-page__story">
        <div className="landing-page__story__images">
          <img
            className="landing-page__story__images__left-image"
            src={HomerImage}
          />
          <img
            className="landing-page__story__images__right-image"
            src={HomerImage}
          />
        </div>
        <div className="landing-page__story__section">
          <div className="landing-page__story__section__title">
            Our story and values
          </div>
          <div className="landing-page__story__section__description">
            Proin quis lacus elit. Vestibulum suscipit molestie tortor vitae
            suscipit. Nunc cursus elit dui, et sagittis urna ullamcorper sit
            amet. Sed condimentum mi eget orci tincidunt, vestibulum consectetur
            arcu scelerisque. Cras ut malesuada nisl. Praesent rutrum arcu et
            orci blandit viverra at eu magna. Nam tempor dolor lorem. Integer ut
            diam molestie, mattis arcu a, fermentum elit. Suspendisse vehicula,
            nibh sit amet auctor bibendum, eros odio suscipit erat, ut fringilla
            nunc eros sit amet nulla. Nam at finibus quam. Fusce pulvinar neque
            nec luctus lacinia. Sed vel dolor tincidunt, faucibus ligula quis,
            pretium ex. Vestibulum eget maximus nisl, eu pretium nisl. Fusce
            aliquam bibendum est, id eleifend diam porttitor eu. Donec massa
            justo, imperdiet eget sapien non, pretium molestie justo. Proin quis
            lacus elit. Vestibulum suscipit molestie tortor vitae suscipit. Nunc
            cursus elit dui, et sagittis urna ullamcorper sit amet. Sed
            condimentum mi eget orci tincidunt, vestibulum consectetur arcu
            scelerisque. Cras ut malesuada nisl. Praesent rutrum arcu et orci
            blandit viverra at eu magna. Nam tempor dolor lorem. Integer ut diam
            molestie, mattis arcu a, fermentum elit. Suspendisse vehicula, nibh
            sit amet auctor bibendum, eros odio suscipit erat, ut fringilla nunc
            eros sit amet nulla. Nam at finibus quam. Fusce pulvinar neque nec
            luctus lacinia. Sed vel dolor tincidunt, faucibus ligula quis,
            pretium ex. Vestibulum eget maximus nisl, eu pretium nisl. Fusce
            aliquam bibendum est, id eleifend diam porttitor eu. Donec massa
            justo, imperdiet eget sapien non, pretium molestie justo.
          </div>
        </div>
      </div>
      <div className="landing-page__text">
        <div className="landing-page__text__section">
          <div className="landing-page__text__section__title">TEXT</div>
          <div className="landing-page__text__section__text">
            Proin quis lacus elit. Vestibulum suscipit molestie tortor vitae
            suscipit. Nunc cursus elit dui, et sagittis urna ullamcorper sit
            amet. Sed condimentum mi eget orci tincidunt, vestibulum consectetur
            arcu scelerisque. Cras ut malesuada nisl. Praesent rutrum arcu et
            orci blandit viverra at eu magna. Nam tempor dolor lorem. Integer ut
            diam molestie, mattis arcu a, fermentum elit. Suspendisse vehicula,
            nibh sit amet auctor bibendum, eros odio suscipit erat, ut fringilla
            nunc eros sit amet nulla. Nam at finibus quam. Fusce pulvinar neque
            nec luctus lacinia. Sed vel dolor tincidunt, faucibus ligula quis,
            pretium ex. Vestibulum eget maximus nisl, eu pretium nisl. Fusce
            aliquam bibendum est, id eleifend diam porttitor eu. Donec massa
            justo, imperdiet eget sapien non, pretium molestie justo.
          </div>
        </div>
        <div className="landing-page__text__section">
          <div className="landing-page__text__section__title">TEXT</div>
          <div className="landing-page__text__section__text">
            Proin quis lacus elit. Vestibulum suscipit molestie tortor vitae
            suscipit. Nunc cursus elit dui, et sagittis urna ullamcorper sit
            amet. Sed condimentum mi eget orci tincidunt, vestibulum consectetur
            arcu scelerisque. Cras ut malesuada nisl. Praesent rutrum arcu et
            orci blandit viverra at eu magna. Nam tempor dolor lorem. Integer ut
            diam molestie, mattis arcu a, fermentum elit. Suspendisse vehicula,
            nibh sit amet auctor bibendum, eros odio suscipit erat, ut fringilla
            nunc eros sit amet nulla. Nam at finibus quam. Fusce pulvinar neque
            nec luctus lacinia. Sed vel dolor tincidunt, faucibus ligula quis,
            pretium ex. Vestibulum eget maximus nisl, eu pretium nisl. Fusce
            aliquam bibendum est, id eleifend diam porttitor eu. Donec massa
            justo, imperdiet eget sapien non, pretium molestie justo.
          </div>
        </div>
        <div className="landing-page__text__section">
          <div className="landing-page__text__section__title">TEXT</div>
          <div className="landing-page__text__section__text">
            Proin quis lacus elit. Vestibulum suscipit molestie tortor vitae
            suscipit. Nunc cursus elit dui, et sagittis urna ullamcorper sit
            amet. Sed condimentum mi eget orci tincidunt, vestibulum consectetur
            arcu scelerisque. Cras ut malesuada nisl. Praesent rutrum arcu et
            orci blandit viverra at eu magna. Nam tempor dolor lorem. Integer ut
            diam molestie, mattis arcu a, fermentum elit. Suspendisse vehicula,
            nibh sit amet auctor bibendum, eros odio suscipit erat, ut fringilla
            nunc eros sit amet nulla. Nam at finibus quam. Fusce pulvinar neque
            nec luctus lacinia. Sed vel dolor tincidunt, faucibus ligula quis,
            pretium ex. Vestibulum eget maximus nisl, eu pretium nisl. Fusce
            aliquam bibendum est, id eleifend diam porttitor eu. Donec massa
            justo, imperdiet eget sapien non, pretium molestie justo.
          </div>
        </div>
      </div>
    </div>
  );
};

export default LandingPage;
