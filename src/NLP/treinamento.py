import spacy
from spacy.training.example import Example

nlp = spacy.load("pt_core_news_lg")

ner = nlp.get_pipe("ner")
ner.add_label("PERIGO")

exemplos_perigo = [
    ("Assalto no centro da cidade.", {"entities": [(0, 7, "RJ")]}),
    ("Tiroteio próximo à escola.", {"entities": [(0, 8, "RJ")]}),
    ("Confusão durante o protesto.", {"entities": [(0, 8, "RJ")]}),
    ("Arrastão na praia.", {"entities": [(0, 7, "RJ")]}),
    ("Incidente com reféns no banco.", {"entities": [(0, 8, "RJ")]}),
    ("Ataque terrorista no metrô.", {"entities": [(0, 7, "RJ")]}),
    ("Explosão em prédio residencial.", {"entities": [(0, 8, "RJ")]}),
    ("Naufrágio de embarcação no mar.", {"entities": [(0, 8, "RJ")]}),
    ("Desabamento de ponte durante tempestade.", {"entities": [(0, 10, "RJ")]}),
    ("Atropelamento em cruzamento movimentado.", {"entities": [(0, 11, "RJ")]}),
    ("Incêndio em fábrica industrial.", {"entities": [(0, 7, "RJ")]}),
    ("Briga generalizada em bar lotado.", {"entities": [(0, 8, "RJ")]}),
    ("Furacão se aproximando da costa.", {"entities": [(0, 7, "RJ")]}),
    ("Deslizamento de terra em área residencial.", {"entities": [(0, 11, "RJ")]}),
    ("Explosão de gás em edifício comercial.", {"entities": [(0, 8, "RJ")]}),
    ("Acidente de avião no aeroporto.", {"entities": [(0, 7, "RJ")]}),
    ("Ataque de animais selvagens na floresta.", {"entities": [(0, 7, "RJ")]}),
    ("Riachos transbordando após chuvas intensas.", {"entities": [(0, 7, "RJ")]}),
    ("Atentado em centro de convenções.", {"entities": [(0, 7, "RJ")]}),
    ("Situaçaõ de abandono em Santa Catarina", {"entities": [(12, 20, "RJ")]}),
    ("Colisão entre trens na estação ferroviária.", {"entities": [(0, 7, "RJ")]}),
]



for _ in range(22):  
    for texto, anotacao in exemplos_perigo:
        exemplo = Example.from_dict(nlp.make_doc(texto), anotacao)
        nlp.update([exemplo])

nlp.to_disk("anormalidade")
