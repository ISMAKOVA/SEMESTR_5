import spacy

nlp = spacy.load("en_core_web_sm")
doc = nlp("Apple is looking at buying U.K. startup for $1 billion. \
                 This is a very promising startup.")
vocab = {}
for token in doc:
    if token.text not in vocab.keys():
      vocab[token.text] = 1
    else:
      vocab[token.text] += 1
print(vocab)

# Output:
# {'Apple': 1, 'is': 2, 'looking': 1, 'at': 1, 'buying': 1, 'U.K.': 1, 'startup': 2, 'for': 1, '$': 1, '1': 1, 'billion': 1, '.': 2, 'This': 1, 'a': 1, 'very': 1, 'promising': 1}